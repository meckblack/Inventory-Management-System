namespace IMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPurchase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Purchase",
                c => new
                    {
                        PurchaseId = c.Int(nullable: false, identity: true),
                        PurchaseDate = c.DateTime(nullable: false, precision: 0),
                        PurchaseBillNo = c.String(nullable: false, unicode: false),
                        PurchaseProductName = c.String(nullable: false, unicode: false),
                        PurchaseQuantity = c.Int(nullable: false),
                        PurchaseCostRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PurchaseCostTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PurchasePayment = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PurchaseDescription = c.String(nullable: false, unicode: false),
                        PurcahseBalance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PurchaseMode = c.Int(nullable: false),
                        PurchaseDueDate = c.DateTime(nullable: false, precision: 0),
                        PurchaseSupplier = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.PurchaseId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Purchase");
        }
    }
}
