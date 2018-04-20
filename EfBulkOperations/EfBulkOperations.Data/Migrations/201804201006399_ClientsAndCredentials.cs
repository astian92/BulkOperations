namespace EfBulkOperations.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClientsAndCredentials : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClientCredentials",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Username = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        LastLogin = c.DateTime(),
                        Level = c.Int(nullable: false),
                        ClientId = c.Guid(nullable: false),
                        Created_Date_Utc = c.DateTime(nullable: false),
                        Last_Modified_Date_Utc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.ClientId)
                .Index(t => t.ClientId, unique: true, name: "IX_SingleClient");
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        Created_Date_Utc = c.DateTime(nullable: false),
                        Last_Modified_Date_Utc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClientCredentials", "ClientId", "dbo.Clients");
            DropIndex("dbo.ClientCredentials", "IX_SingleClient");
            DropTable("dbo.Clients");
            DropTable("dbo.ClientCredentials");
        }
    }
}
