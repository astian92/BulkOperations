using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EfBulkOperations.Client.Constants;
using EfBulkOperations.Data.Context;

namespace EfBulkOperations.Client.Testers
{
    public abstract class TestBase
    {
        public async Task Clean()
        {
            using (var dbContext = new BulkDataContext(DataConstants.ConnectionString))
            {
                dbContext.Employees.RemoveRange(dbContext.Employees);
                dbContext.Companies.RemoveRange(dbContext.Companies);
                dbContext.ClientCredentials.RemoveRange(dbContext.ClientCredentials);
                dbContext.Clients.RemoveRange(dbContext.Clients);

                await dbContext.SaveChangesAsync();
            }
        }
    }
}
