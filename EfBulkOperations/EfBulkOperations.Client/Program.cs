using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EfBulkOperations.Client.Testers;

namespace EfBulkOperations.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //Simple employee test
            var employeeTester = new EmployeeTester();

            //employeeTester.EF_SimpleEmployeeTest().Wait();
            //employeeTester.Clean().Wait();

            employeeTester.Bulk_SimpleEmployeeTest().Wait();
            employeeTester.Clean().Wait();
        }
    }
}
