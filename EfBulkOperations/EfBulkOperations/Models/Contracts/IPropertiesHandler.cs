using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EfBulkOperations.Models.Contracts
{
    /// <summary>
    /// Provides simple properties(database columns) and meta properties (foreignKey entity properties)
    /// </summary>
    public interface IPropertiesHandler
    {
        IEnumerable<PropertyInfo> GetProperties(Type type);
        IEnumerable<PropertyInfo> GetSimpleProperties(Type type);
    }
}
