namespace Rieltor.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Rieltor.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Rieltor.Models.ApplicationDbContext context)
        {
            context.Areas.AddOrUpdate(new Models.Area { Id = "1", Name = "Lviv Area" });
            context.Areas.AddOrUpdate(new Models.Area { Id = "2", Name = "Kyiv Area" });
            context.Areas.AddOrUpdate(new Models.Area { Id = "3", Name = "Doneck" });

            context.Cities.AddOrUpdate(new Models.City { Id = "1", Name = "Lviv", AreaId = "1" });
            context.Cities.AddOrUpdate(new Models.City { Id = "2", Name = "Kiyv", AreaId = "2" });
            context.Cities.AddOrUpdate(new Models.City { Id = "8", Name = "Sambir", AreaId = "1" });

            context.Neighborhoods.AddOrUpdate(new Models.Neighborhood { Id = "1", Name = "Zaliznuchnuy", CityId = "1" });
            context.Neighborhoods.AddOrUpdate(new Models.Neighborhood { Id = "2", Name = "Frankivskiy", CityId = "1" });
            context.Neighborhoods.AddOrUpdate(new Models.Neighborhood { Id = "3", Name = "Syxiv", CityId = "1" });
            context.Neighborhoods.AddOrUpdate(new Models.Neighborhood { Id = "4", Name = "Podol", CityId = "2" });
            context.Neighborhoods.AddOrUpdate(new Models.Neighborhood { Id = "5", Name = "Podol", CityId = "8" });

            context.Addresses.AddOrUpdate(new Models.Address { Id = "1", Street = "Lublinska", Number = "5", CityId = "1", NeighborhoodId = "1" });
            context.Addresses.AddOrUpdate(new Models.Address { Id = "2", Street = "S.Petlury", Number = "25", CityId = "1", NeighborhoodId = "1" });
            context.Addresses.AddOrUpdate(new Models.Address { Id = "3", Street = "V.Velukogo", Number = "15", CityId = "1", NeighborhoodId = "2" });
            context.Addresses.AddOrUpdate(new Models.Address { Id = "4", Street = "Suxivska", Number = "5", CityId = "1", NeighborhoodId = "3" });
            context.Addresses.AddOrUpdate(new Models.Address { Id = "5", Street = "Khruchatyk", Number = "5", CityId = "2", NeighborhoodId = "4" });
            context.Addresses.AddOrUpdate(new Models.Address { Id = "6", Street = "Lublinska", Number = "5", CityId = "1", NeighborhoodId = "1" });
            context.Addresses.AddOrUpdate(new Models.Address { Id = "7", Street = "S.Petlury", Number = "25", CityId = "1", NeighborhoodId = "1" });
            context.Addresses.AddOrUpdate(new Models.Address { Id = "8", Street = "V.Velukogo", Number = "15", CityId = "8", NeighborhoodId = "5" });
            //  context.Addresses.AddOrUpdate(new Models.Address { Id = "4", Street = "Suxivska", Number = "5", CityId = "1", NeighborhoodId = "3" });

            context.Posts.AddOrUpdate(new Models.Post { Id = "1", Price = "20000", Description = "Flor in the nice become", AllArea = "35", LiveArea = "20", CookArea = "15", AllFlor = "9", Flor = "1", CountRoom = "2", UrlSeo = "q" });          //  This method will be called after migrating to the latest version.
            context.Posts.AddOrUpdate(new Models.Post { Id = "2", Price = "5550000", Description = "without midle", AllArea = "35", LiveArea = "20", CookArea = "15", AllFlor = "9", Flor = "2", CountRoom = "4", UrlSeo = "qw" });
            context.Posts.AddOrUpdate(new Models.Post { Id = "3", Price = "205000", Description = "dont for live ", AllArea = "35", LiveArea = "20", CookArea = "15", AllFlor = "9", Flor = "3", CountRoom = "4", UrlSeo = "e" });
            context.Posts.AddOrUpdate(new Models.Post { Id = "4", Price = "760000", Description = "for yong family", AllArea = "35", LiveArea = "20", CookArea = "15", AllFlor = "9", Flor = "4", CountRoom = "3", UrlSeo = "qr" });
            context.Posts.AddOrUpdate(new Models.Post { Id = "5", Price = "20000", Description = "Flor in the nice become", AllArea = "35", LiveArea = "20", CookArea = "15", AllFlor = "9", Flor = "5", CountRoom = "1", UrlSeo = "qt" });          //  This method will be called after migrating to the latest version.
            context.Posts.AddOrUpdate(new Models.Post { Id = "6", Price = "5550000", Description = "without midle", AllArea = "35", LiveArea = "20", CookArea = "15", AllFlor = "9", Flor = "6", CountRoom = "1", UrlSeo = "qy" });
            context.Posts.AddOrUpdate(new Models.Post { Id = "7", Price = "205000", Description = "dont for live ", AllArea = "35", LiveArea = "20", CookArea = "15", AllFlor = "9", Flor = "7", CountRoom = "2", UrlSeo = "qu" });
            context.Posts.AddOrUpdate(new Models.Post { Id = "8", Price = "760000", Description = "for yong family", AllArea = "35", LiveArea = "20", CookArea = "15", AllFlor = "9", Flor = "8", CountRoom = "5", UrlSeo = "qi" });

            context.Categories.AddOrUpdate(new Models.Category { Id = "Cat1", Name = "Buy", UrlSeo = "qw" });
            context.Categories.AddOrUpdate(new Models.Category { Id = "Cat2", Name = "Sall", UrlSeo = "qe" });
            context.Categories.AddOrUpdate(new Models.Category { Id = "Cat3", Name = "rent", UrlSeo = "qr" });

            context.PostCategories.AddOrUpdate(new Models.PostCategory { PostId = "4", CategoryId = "Cat3" });
            context.PostCategories.AddOrUpdate(new Models.PostCategory { PostId = "3", CategoryId = "Cat3" });
            context.PostCategories.AddOrUpdate(new Models.PostCategory { PostId = "1", CategoryId = "Cat2" });
            context.PostCategories.AddOrUpdate(new Models.PostCategory { PostId = "2", CategoryId = "Cat3" });
            context.PostCategories.AddOrUpdate(new Models.PostCategory { PostId = "5", CategoryId = "Cat3" });
            context.PostCategories.AddOrUpdate(new Models.PostCategory { PostId = "8", CategoryId = "Cat3" });

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
