namespace IMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editedProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "Quantity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "Quantity");
        }
    }
}
