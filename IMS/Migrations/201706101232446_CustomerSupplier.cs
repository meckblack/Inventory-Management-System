namespace IMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerSupplier : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admin",
                c => new
                    {
                        AdminId = c.Int(nullable: false, identity: true),
                        AdminUsername = c.String(nullable: false, unicode: false),
                        AdminPassword = c.String(nullable: false, unicode: false),
                        AdminComfirmPassword = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.AdminId);
            
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
            
            CreateTable(
                "dbo.Supplier",
                c => new
                    {
                        SupplierId = c.Int(nullable: false, identity: true),
                        SupplierName = c.String(nullable: false, unicode: false),
                        SupplierAddress = c.String(nullable: false, unicode: false),
                        SupplierContact = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.SupplierId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Supplier");
            DropTable("dbo.Customer");
            DropTable("dbo.Admin");
        }
    }
}
