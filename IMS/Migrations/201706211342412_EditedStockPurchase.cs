namespace IMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditedStockPurchase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StockPurchase", "StockPurchaseSupplier", c => c.String(nullable: false, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.StockPurchase", "StockPurchaseSupplier");
        }
    }
}
