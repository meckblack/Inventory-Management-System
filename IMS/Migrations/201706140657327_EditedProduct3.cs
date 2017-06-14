namespace IMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditedProduct3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "ProductDescription", c => c.String(nullable: false, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "ProductDescription");
        }
    }
}
