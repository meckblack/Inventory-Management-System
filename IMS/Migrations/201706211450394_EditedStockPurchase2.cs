namespace IMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditedStockPurchase2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.StockPurchase", "StockPurchaseBillNo", c => c.String(nullable: false, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.StockPurchase", "StockPurchaseBillNo", c => c.Int(nullable: false));
        }
    }
}
