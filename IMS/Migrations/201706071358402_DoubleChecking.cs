namespace IMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DoubleChecking : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(nullable: false, unicode: false),
                        CustomerAddress = c.String(nullable: false, unicode: false),
                        CustomerContact = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.CustomerId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Customer");
        }
    }
}
