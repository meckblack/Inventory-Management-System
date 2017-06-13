namespace IMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CheckUp : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ProductId = c.String(nullable: false, maxLength: 128, unicode: false, storeType: "nvarchar"),
                        ProductName = c.String(nullable: false, unicode: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Category", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Stock",
                c => new
                    {
                        StockId = c.Int(nullable: false, identity: true),
                        StockName = c.String(nullable: false, unicode: false),
                        StockCategory = c.String(nullable: false, unicode: false),
                        StockBuyingPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StockSellingPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StockSupplier = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.StockId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "CategoryId", "dbo.Category");
            DropIndex("dbo.Product", new[] { "CategoryId" });
            DropTable("dbo.Stock");
            DropTable("dbo.Product");
            DropTable("dbo.Category");
        }
    }
}
