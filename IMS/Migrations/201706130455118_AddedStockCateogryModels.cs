namespace IMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedStockCateogryModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Stock",
                c => new
                {
                    StockId = c.Int(nullable: false, identity: true),
                    StockName = c.String(nullable: false, unicode: false),
                    StockCategory = c.String(nullable: false, unicode: false),
                    StockBullingPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    StockSellingPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    StockSupplier = c.String(nullable: false,unicode: false)
                })
                .PrimaryKey(t => t.StockId);

            CreateTable(
                "dbo.Category",
                c => new
                {
                    CategoryId = c.Int(nullable: false, identity: true),
                    ProductName = c.String(nullable: false, unicode: false),
                    CategoryName = c.String(nullable: false, unicode: false),
                })
                .PrimaryKey(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Stock");            
            DropTable("dbo.Category");
        }
    }
}
