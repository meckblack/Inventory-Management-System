namespace IMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewStock : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Stock",
                c => new
                    {
                        StockId = c.Int(nullable: false, identity: true),
                        StockName = c.String(nullable: false, unicode: false),
                        StockBuyingPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StockSellingPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CategoryId = c.Int(nullable: false),
                        SupplierId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StockId)
                .ForeignKey("dbo.Category", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Supplier", t => t.SupplierId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.SupplierId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stock", "SupplierId", "dbo.Supplier");
            DropForeignKey("dbo.Stock", "CategoryId", "dbo.Category");
            DropIndex("dbo.Stock", new[] { "SupplierId" });
            DropIndex("dbo.Stock", new[] { "CategoryId" });
            DropTable("dbo.Stock");
        }
    }
}
