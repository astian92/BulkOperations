using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EfBulkOperations.Data.Context;

namespace EfBulkOperations.Data.Migrations
{
    public class BulkDataConfiguration : DbMigrationsConfiguration<BulkDataContext>
    {
        public BulkDataConfiguration()
        {
            // DON'T use automatic migrations. Use explicit migrations instead (via Add-Migration command).
        }

        protected override void Seed(BulkDataContext context)
        {
        }
    }
}
