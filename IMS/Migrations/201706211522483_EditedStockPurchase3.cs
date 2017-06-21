namespace IMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditedStockPurchase3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StockPurchase", "StockPurchaseCostTotal", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.StockPurchase", "StockPurchaseBuyingTotal");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StockPurchase", "StockPurchaseBuyingTotal", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.StockPurchase", "StockPurchaseCostTotal");
        }
    }
}
