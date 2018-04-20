using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EfBulkOperations.Data.Models;

namespace EfBulkOperations.Data.Context
{
    public class BulkDataContext : DbContext
    {
        private const string CONNECTION_STRING = "BulkTestBase";

        public BulkDataContext()
            : this($"name={CONNECTION_STRING}")
        {
        }

        public BulkDataContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }

        public virtual DbSet<EmployeeEntity> Employees { get; set; }

        public virtual DbSet<CompanyEntity> Companies { get; set; }

        public virtual DbSet<ClientEntity> Clients { get; set; }

        public virtual DbSet<ClientCredentialsEntity> ClientCredentials { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Convention to enable cascade delete for any required relationships.
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            // Convention to add a cascade delete to the join table from both tables involved in a many to many relationship.
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }
    }
}
