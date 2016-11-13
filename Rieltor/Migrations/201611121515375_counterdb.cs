namespace Rieltor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class counterdb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PostViews",
                c => new
                    {
                        PostId = c.String(nullable: false, maxLength: 128),
                        ViewsId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.PostId, t.ViewsId })
                .ForeignKey("dbo.Post", t => t.PostId, cascadeDelete: true)
                .ForeignKey("dbo.Views", t => t.ViewsId, cascadeDelete: true)
                .Index(t => t.PostId)
                .Index(t => t.ViewsId);
            
            CreateTable(
                "dbo.Views",
                c => new
                    {
                        ViewsId = c.String(nullable: false, maxLength: 128),
                        IpAddress = c.String(),
                        VisitData = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ViewsId);
            
            DropColumn("dbo.Post", "CountViews");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Post", "CountViews", c => c.Int(nullable: false));
            DropForeignKey("dbo.PostViews", "ViewsId", "dbo.Views");
            DropForeignKey("dbo.PostViews", "PostId", "dbo.Post");
            DropIndex("dbo.PostViews", new[] { "ViewsId" });
            DropIndex("dbo.PostViews", new[] { "PostId" });
            DropTable("dbo.Views");
            DropTable("dbo.PostViews");
        }
    }
}
