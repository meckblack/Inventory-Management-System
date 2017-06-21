namespace IMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPurchaseStock : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StockPurchase",
                c => new
                    {
                        StockPurchaseId = c.Int(nullable: false, identity: true),
                        StockPurchaseDate = c.DateTime(nullable: false, precision: 0),
                        StockPurchaseBillNo = c.Int(nullable: false),
                        StockPurchaseProductName = c.String(nullable: false, unicode: false),
                        StockPurchaseQuantity = c.Int(nullable: false),
                        StockPurchaseCostRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StockPurchaseBuyingTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StockPurchasePayment = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StockPurchaseDescription = c.String(nullable: false, unicode: false),
                        StockPurcahseBalance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StockPurchaseMode = c.Int(nullable: false),
                        StockPurchaseDueDate = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.StockPurchaseId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.StockPurchase");
        }
    }
}
