namespace IMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationTwo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Role", "CanManageStaff", c => c.Boolean(nullable: false));
            AddColumn("dbo.Role", "CanManageInventory", c => c.Boolean(nullable: false));
            AddColumn("dbo.Role", "CanManageSuppliers", c => c.Boolean(nullable: false));
            AddColumn("dbo.Role", "CanManageCustomers", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Role", "CanManageCustomers");
            DropColumn("dbo.Role", "CanManageSuppliers");
            DropColumn("dbo.Role", "CanManageInventory");
            DropColumn("dbo.Role", "CanManageStaff");
        }
    }
}
