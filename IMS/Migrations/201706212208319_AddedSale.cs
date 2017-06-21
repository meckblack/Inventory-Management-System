namespace IMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSale : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sale",
                c => new
                    {
                        SaleId = c.Int(nullable: false, identity: true),
                        SaleDate = c.DateTime(nullable: false, precision: 0),
                        SaleBillNo = c.String(nullable: false, unicode: false),
                        SaleProductName = c.String(nullable: false, unicode: false),
                        SaleQuantity = c.Int(nullable: false),
                        SaleCostRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SaleCostTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SalePayment = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SaleDescription = c.String(nullable: false, unicode: false),
                        SaleBalance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SaleMode = c.Int(nullable: false),
                        SaleDueDate = c.DateTime(nullable: false, precision: 0),
                        SaleCustomer = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.SaleId);
            
            DropTable("dbo.StockPurchase");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.StockPurchase",
                c => new
                    {
                        StockPurchaseId = c.Int(nullable: false, identity: true),
                        StockPurchaseDate = c.DateTime(nullable: false, precision: 0),
                        StockPurchaseBillNo = c.String(nullable: false, unicode: false),
                        StockPurchaseProductName = c.String(nullable: false, unicode: false),
                        StockPurchaseQuantity = c.Int(nullable: false),
                        StockPurchaseCostRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StockPurchaseCostTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StockPurchasePayment = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StockPurchaseDescription = c.String(nullable: false, unicode: false),
                        StockPurcahseBalance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StockPurchaseMode = c.Int(nullable: false),
                        StockPurchaseDueDate = c.DateTime(nullable: false, precision: 0),
                        StockPurchaseSupplier = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.StockPurchaseId);
            
            DropTable("dbo.Sale");
        }
    }
}
