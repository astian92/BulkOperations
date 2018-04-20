using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfBulkOperations.Data.Models
{
    public abstract class EntityBase
    {
        protected EntityBase()
        {
            Id = Guid.NewGuid();
            Created_Date_Utc = DateTime.UtcNow;
        }

        [Key]
        public Guid Id { get; set; }

        public DateTime Created_Date_Utc { get; set; }

        public DateTime? Last_Modified_Date_Utc { get; set; }
    }
}
