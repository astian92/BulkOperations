using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using EfBulkOperations.Models.Contracts;

namespace EfBulkOperations
{
    public class BulkOperations : IBulkOperations
    {
        private readonly ITableHandler _tableHandler;

        public BulkOperations(ITableHandler tableHandler)
        {
            _tableHandler = tableHandler;
        }

        public async Task BulkInsertAsync<T>(DbContext context, IEnumerable<T> entities)
        {
            using (var connection = new SqlConnection(context.Database.Connection.ConnectionString))
            {
                await connection.OpenAsync();
                await InsertAsync(context, connection, (IEnumerable<object>)entities, typeof(T));
            }
        }

        private async Task InsertAsync(DbContext dbContext, SqlConnection connection, IEnumerable<object> entities, Type entitiesType)
        {
            var dtable = _tableHandler.CreateTable(entities, entitiesType);
            var bulk = CreateSqlBulkCopy(dbContext, connection, dtable, entitiesType);

            await bulk.WriteToServerAsync(dtable);
        }

        private SqlBulkCopy CreateSqlBulkCopy(DbContext context, SqlConnection connection, DataTable table, Type type, int timeout = 0)
        {
            var bulkCopy = new SqlBulkCopy(connection)
            {
                DestinationTableName = _tableHandler.GetTableName(context, type)
            };

            //Map columns to their names (otherwise it missmatches them for some reason)
            foreach (DataColumn prepped in table.Columns)
            {
                bulkCopy.ColumnMappings.Add(prepped.ColumnName, prepped.ColumnName);
            }

            bulkCopy.BulkCopyTimeout = timeout;
            return bulkCopy;
        }
    }
}
