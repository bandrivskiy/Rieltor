namespace Rieltor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class invite : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AllRentViewModel", "Address_Id", "dbo.Address");
            DropForeignKey("dbo.AllRentViewModel", "City_Id", "dbo.City");
            DropForeignKey("dbo.AllRentViewModel", "Neigh_Id", "dbo.Neighborhood");
            DropForeignKey("dbo.AllRentViewModel", "Post_Id", "dbo.Post");
            DropIndex("dbo.AllRentViewModel", new[] { "Address_Id" });
            DropIndex("dbo.AllRentViewModel", new[] { "City_Id" });
            DropIndex("dbo.AllRentViewModel", new[] { "Neigh_Id" });
            DropIndex("dbo.AllRentViewModel", new[] { "Post_Id" });
            AddColumn("dbo.Post", "CountViews", c => c.Int(nullable: false));
            DropTable("dbo.AllRentViewModel");
            DropTable("dbo.RentViewModel");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.RentViewModel",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Street = c.String(),
                        Number = c.String(),
                        CityId = c.String(),
                        NeighborhoodId = c.String(),
                        Flor = c.String(),
                        AllFlor = c.String(),
                        Price = c.String(),
                        Description = c.String(),
                        AllArea = c.String(),
                        CountRoom = c.String(),
                        LiveArea = c.String(),
                        CookArea = c.String(),
                        UrlSeo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AllRentViewModel",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        CountRoom = c.String(),
                        Flor = c.String(),
                        AllFlor = c.String(),
                        Price = c.String(),
                        Description = c.String(),
                        AllArea = c.String(),
                        LiveArea = c.String(),
                        CookArea = c.String(),
                        UrlSlug = c.String(),
                        Address_Id = c.String(maxLength: 128),
                        City_Id = c.String(maxLength: 128),
                        Neigh_Id = c.String(maxLength: 128),
                        Post_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.Post", "CountViews");
            CreateIndex("dbo.AllRentViewModel", "Post_Id");
            CreateIndex("dbo.AllRentViewModel", "Neigh_Id");
            CreateIndex("dbo.AllRentViewModel", "City_Id");
            CreateIndex("dbo.AllRentViewModel", "Address_Id");
            AddForeignKey("dbo.AllRentViewModel", "Post_Id", "dbo.Post", "Id");
            AddForeignKey("dbo.AllRentViewModel", "Neigh_Id", "dbo.Neighborhood", "Id");
            AddForeignKey("dbo.AllRentViewModel", "City_Id", "dbo.City", "Id");
            AddForeignKey("dbo.AllRentViewModel", "Address_Id", "dbo.Address", "Id");
        }
    }
}
