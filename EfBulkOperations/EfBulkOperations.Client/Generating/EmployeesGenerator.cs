using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EfBulkOperations.Data.Models;
using EfBulkOperations.Data.Models.ComplexTypes;

namespace EfBulkOperations.Client.Generating
{
    public static class EmployeesGenerator
    {
        public static IEnumerable<EmployeeEntity> GenerateEmployees(int count, bool includeCompanies = true, Action<EmployeeEntity> overrides = null)
        {
            var employees = new List<EmployeeEntity>();
            var random = new Random();

            for (int i = 0; i < count; i++)
            {
                var employee = new EmployeeEntity()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "First Name " + i + random.Next(int.MaxValue),
                    LastName = "Last Name " + i + random.Next(int.MaxValue),
                    Email = "Email " + i + random.Next(int.MaxValue),
                    DateOfBirth = DateTime.Today.AddYears(-random.Next(50)),
                    Address = new Address()
                    {
                        City = "City " + i + random.Next(int.MaxValue),
                        Country = "Country " + i + random.Next(int.MaxValue),
                        Street = "Street " + i + random.Next(int.MaxValue)
                    },
                    Coeficient = (decimal)(1000 * random.NextDouble()),
                    FirstDay = DateTime.Today.AddDays(-random.Next(40)),
                    Created_Date_Utc = DateTime.Now,
                    Last_Modified_Date_Utc = DateTime.Now,
                };

                if (includeCompanies)
                {
                    employee.CompanyId = Guid.NewGuid();
                    employee.Company = new CompanyEntity()
                    {
                        Id = employee.CompanyId,
                        Name = "Name " + i + random.Next(int.MaxValue),
                        MainQuarters = new Address()
                        {
                            City = "City " + i + random.Next(int.MaxValue),
                            Country = "Country " + i + random.Next(int.MaxValue),
                            Street = "Street " + i + random.Next(int.MaxValue)
                        },
                        StartedDate = DateTime.Today.AddYears(-random.Next(40)),
                        Created_Date_Utc = DateTime.Now,
                        Last_Modified_Date_Utc = DateTime.Now
                    };
                }

                employees.Add(employee);
            }

            return employees;
        }
    }
}
