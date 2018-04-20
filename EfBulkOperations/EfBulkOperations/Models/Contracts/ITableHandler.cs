using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfBulkOperations.Models.Contracts
{
    /// <summary>
    /// Handles the creation and population of the datatable
    /// </summary>
    public interface ITableHandler
    {
        DataTable CreateTable(IEnumerable<object> entities, Type type);
        string GetTableName(DbContext context, Type type);
    }
}
