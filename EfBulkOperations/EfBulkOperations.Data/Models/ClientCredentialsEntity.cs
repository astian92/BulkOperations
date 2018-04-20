using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EfBulkOperations.Data.Models.Enums;

namespace EfBulkOperations.Data.Models
{
    [Table("ClientCredentials")]
    public class ClientCredentialsEntity : EntityBase
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public DateTime? LastLogin { get; set; }

        public CredentialLevel Level { get; set; }

        [ForeignKey(nameof(Client))]
        [Index("IX_SingleClient", IsUnique = true)]
        public Guid ClientId { get; set; }

        public virtual ClientEntity Client { get; set; }

        [NotMapped]
        public string SessionId { get; set; }

        [NotMapped]
        public DateTime SessionIssuedDateTime { get; set; } 

        [NotMapped]
        public SessionType SessionType { get; set; }
    }
}
