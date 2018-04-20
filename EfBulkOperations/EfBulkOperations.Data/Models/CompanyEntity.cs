using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EfBulkOperations.Data.Models.ComplexTypes;

namespace EfBulkOperations.Data.Models
{
    [Table("Companies")]
    public class CompanyEntity : EntityBase
    {
        public CompanyEntity()
        {
            Employees = new HashSet<EmployeeEntity>();
        }

        public string Name { get; set; }

        public DateTime StartedDate { get; set; }

        public Address MainQuarters { get; set; }

        public virtual ICollection<EmployeeEntity> Employees { get; set; }
    }
}
