namespace EfBulkOperations.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmployeesAndCompanies : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        StartedDate = c.DateTime(nullable: false),
                        MainQuarters_Country = c.String(),
                        MainQuarters_City = c.String(),
                        MainQuarters_Street = c.String(),
                        Created_Date_Utc = c.DateTime(nullable: false),
                        Last_Modified_Date_Utc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        FirstDay = c.DateTime(),
                        Coeficient = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Address_Country = c.String(),
                        Address_City = c.String(),
                        Address_Street = c.String(),
                        CompanyId = c.Guid(nullable: false),
                        Created_Date_Utc = c.DateTime(nullable: false),
                        Last_Modified_Date_Utc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CompanyId)
                .Index(t => t.CompanyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "CompanyId", "dbo.Companies");
            DropIndex("dbo.Employees", new[] { "CompanyId" });
            DropTable("dbo.Employees");
            DropTable("dbo.Companies");
        }
    }
}
