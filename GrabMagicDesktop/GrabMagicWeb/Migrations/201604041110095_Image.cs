namespace GrabMagicWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Image : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        ImageId = c.Int(nullable: false, identity: true),
                        FileName = c.String(),
                        Date = c.DateTime(nullable: false),
                        Screenshot_ImageId = c.Int(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ImageId)
                .ForeignKey("dbo.Images", t => t.Screenshot_ImageId)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.Screenshot_ImageId)
                .Index(t => t.User_Id);
            
            AlterColumn("dbo.AspNetUsers", "UserName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Images", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Images", "Screenshot_ImageId", "dbo.Images");
            DropIndex("dbo.Images", new[] { "User_Id" });
            DropIndex("dbo.Images", new[] { "Screenshot_ImageId" });
            AlterColumn("dbo.AspNetUsers", "UserName", c => c.String());
            DropTable("dbo.Images");
        }
    }
}
