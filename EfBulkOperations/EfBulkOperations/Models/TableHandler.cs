using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Mapping;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using EfBulkOperations.Models.Contracts;

namespace EfBulkOperations.Models
{
    public class TableHandler : ITableHandler
    {
        private readonly IPropertiesHandler _propsHandler;

        public TableHandler(IPropertiesHandler propertiesHandler)
        {
            _propsHandler = propertiesHandler;
        }

        public DataTable CreateTable(IEnumerable<object> entities, Type type)
        {
            //var properties = _propsHandler.GetSimpleProperties(type);
            var properties = _propsHandler.GetProperties(type);

            var dtable = GetTable(type, properties);
            PopulateTable(dtable, entities, properties);

            return dtable;
        }

        public string GetTableName(DbContext context, Type type)
        {
            var metadata = ((IObjectContextAdapter)context).ObjectContext.MetadataWorkspace;
            var objectItemCollection = (ObjectItemCollection)metadata.GetItemCollection(DataSpace.OSpace);

            var entityType = metadata
                    .GetItems<EntityType>(DataSpace.OSpace)
                    .Single(e => objectItemCollection.GetClrType(e) == type);

            var entitySet = metadata
                .GetItems<EntityContainer>(DataSpace.CSpace)
                .Single()
                .EntitySets
                .Single(s => s.ElementType.Name == entityType.Name);

            var mapping = metadata.GetItems<EntityContainerMapping>(DataSpace.CSSpace)
                    .Single()
                    .EntitySetMappings
                    .Single(s => s.EntitySet == entitySet);

            var table = mapping
                .EntityTypeMappings.Single()
                .Fragments.Single()
                .StoreEntitySet;

            return (string)table.MetadataProperties["Table"].Value ?? table.Name;
        }

        private DataTable GetTable(Type type, IEnumerable<PropertyInfo> properties)
        {
            var table = new DataTable();
            var columns = GetColumns(type, properties);

            foreach (var column in columns)
            {
                table.Columns.Add(column);
            }

            return table;
        }

        private void PopulateTable(DataTable dtable, IEnumerable<object> entities, IEnumerable<PropertyInfo> properties)
        {
            foreach (var entity in entities)
            {
                //HAVE TO REWORK IT SO IT FETCHES THE PROPERTY VALUES OF THE INSIDE COMPLEX TYPE
                var row = properties.Select(property => property.GetValue(entity, null) ?? DBNull.Value).ToArray();
                dtable.Rows.Add(row);
            }
        }

        private IEnumerable<DataColumn> GetColumns(Type type, IEnumerable<PropertyInfo> properties)
        {
            List<DataColumn> columns = new List<DataColumn>();

            foreach (var property in properties)
            {
                //TODO: THIS IF SUPPORTS ONLY ONE LEVEL OF BACKWARDS: (meaning it checks for the base type of the entity, 
                //but there might be a base type of the base type of the base type... make it recursive
                var propertyType = GetNotNullableType(property);

                if (property.DeclaringType == type || (type.BaseType != null && property.DeclaringType == type.BaseType))
                {
                    columns.Add(new DataColumn(property.Name, propertyType));
                }
                else //complex type
                {
                    columns.Add(new DataColumn(property.DeclaringType.Name + "_" + property.Name, propertyType));
                }
            }

            return columns;
        }

        private Type GetNotNullableType(PropertyInfo property)
        {
            Type propertyType = property.PropertyType;

            if (propertyType.IsGenericType && propertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                propertyType = Nullable.GetUnderlyingType(propertyType);
            }

            return propertyType;
        }
    }
}
