namespace IMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSupplier : DbMigration
    {
        public override void Up()
        {
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
        }
    }
}
