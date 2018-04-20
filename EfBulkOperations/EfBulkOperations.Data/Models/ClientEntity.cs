using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfBulkOperations.Data.Models
{
    [Table("Clients")]
    public class ClientEntity : EntityBase
    {
        public ClientEntity()
        {
            Credentials = new HashSet<ClientCredentialsEntity>();        
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public virtual ICollection<ClientCredentialsEntity> Credentials { get; set; }
    }
}
