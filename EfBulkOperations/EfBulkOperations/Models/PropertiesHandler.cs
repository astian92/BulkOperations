using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using EfBulkOperations.Models.Contracts;

namespace EfBulkOperations.Models
{
    public class PropertiesHandler : IPropertiesHandler
    {
        /// <summary>
        /// TODO: Support for Complex Types and [NotMapped] Attributes
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public IEnumerable<PropertyInfo> GetSimpleProperties(Type type)
        {
            var props = type.GetProperties()
                            .Where(p => p.PropertyType.IsValueType || p.PropertyType == typeof(string)).ToList();

            return props;
        }

        public IEnumerable<PropertyInfo> GetProperties(Type type)
        {
            var properties = new List<PropertyInfo>();

            //get simple properties
            var simpleProperties = GetSimpleProperties(type);
            properties.AddRange(simpleProperties);

            //get complex properties
            var complexTypes = GetComplexTypes(type);
            foreach (var complexType in complexTypes)
            {
                var complexProperties = GetSimpleProperties(complexType);
                properties.AddRange(complexProperties);
            }

            return properties;
        }

        private IEnumerable<Type> GetComplexTypes(Type type)
        {
            var complexTypes = type.GetProperties()
                                   .Where(p => Attribute.GetCustomAttribute(p.PropertyType, typeof(ComplexTypeAttribute)) != null)
                                   .Select(p => p.PropertyType);

            return complexTypes;
        }
    }
}
