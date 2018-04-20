using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfBulkOperations
{
    /// <summary>
    /// Exposes methods that use SqlBulkCopy to send database data in bulk.
    /// </summary>
    public interface IBulkOperations
    {
        /// <summary>
        /// Inserts all the entities in a single bulk insert.
        /// </summary>
        /// <typeparam name="T">The type of the entities that are going to be inserted</typeparam>
        /// <param name="context">The data context to work with</param>
        /// <param name="entities">A list of entities to insert</param>
        /// <returns></returns>
        Task BulkInsertAsync<T>(DbContext context, IEnumerable<T> entities);
    }
}
