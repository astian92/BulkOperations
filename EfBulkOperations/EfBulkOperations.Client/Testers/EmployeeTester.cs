using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EfBulkOperations.Client.Constants;
using EfBulkOperations.Client.Generating;
using EfBulkOperations.Data.Context;
using EfBulkOperations.Models;

namespace EfBulkOperations.Client.Testers
{
    public class EmployeeTester : TestBase
    {
        public async Task EF_SimpleEmployeeTest()
        {
            var employees = EmployeesGenerator.GenerateEmployees(50);

            using (var dbContext = new BulkDataContext(DataConstants.ConnectionString))
            {
                dbContext.Employees.AddRange(employees);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task Bulk_SimpleEmployeeTest()
        {
            var employees = EmployeesGenerator.GenerateEmployees(50);

            using (var dbContext = new BulkDataContext(DataConstants.ConnectionString))
            {
                var bulk = new BulkOperations(new TableHandler(new PropertiesHandler()));
                await bulk.BulkInsertAsync(dbContext, employees);
            }
        }
    }
}
