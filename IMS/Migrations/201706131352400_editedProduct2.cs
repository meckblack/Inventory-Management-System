namespace IMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editedProduct2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "ProductQuantity", c => c.Int(nullable: false));
            DropColumn("dbo.Product", "Quantity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Product", "Quantity", c => c.Int(nullable: false));
            DropColumn("dbo.Product", "ProductQuantity");
        }
    }
}
