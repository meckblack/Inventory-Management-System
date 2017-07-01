namespace IMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationOne : DbMigration
    {
        public override void Up()
        {
            
            CreateTable(
                "dbo.AppUser",
                c => new
                    {
                        AppUserId = c.Int(nullable: false, identity: true),
                        AppUserName = c.String(nullable: false, unicode: false),
                        AppUserEmail = c.String(unicode: false),
                        AppUserPassword = c.String(nullable: false, unicode: false),
                        AppUserComfirmPassword = c.String(nullable: false, unicode: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AppUserId)
                .ForeignKey("dbo.Role", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        RoleName = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.RoleId);
            
            
           
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AppUser", "RoleId", "dbo.Role");
            DropIndex("dbo.AppUser", new[] { "RoleId" });
            DropTable("dbo.Role");
            DropTable("dbo.AppUser");
        }
    }
}
