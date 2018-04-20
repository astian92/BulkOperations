using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EfBulkOperations.Data.Models.ComplexTypes;

namespace EfBulkOperations.Data.Models
{
    [Table("Employees")]
    public class EmployeeEntity : EntityBase
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTime? FirstDay { get; set; }

        public decimal Coeficient { get; set; }

        public Address Address { get; set; }

        public Guid CompanyId { get; set; }

        public virtual CompanyEntity Company { get; set; }
    }
}
