using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Rieltor.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext() : base("RieltorConnection")
        {
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ApplicationDbContext>());
          //  Database.SetInitializer(new CreateDatabaseIfNotExists<ApplicationDbContext>());
             //Database.SetInitializer(new DropCreateDatabaseAlways<ApplicationDbContext>());

        }
        public static ApplicationDbContext Create()
        {

            return new ApplicationDbContext();
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Neighborhood> Neighborhoods { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<PostCategory> PostCategories { get; set; }
        public DbSet<Views> Views { get; set; }
        public DbSet<PostViews> PostViews { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
         //   modelBuilder.Properties().Configure(p => p.IsUnicode(true));

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

      //  public System.Data.Entity.DbSet<Rieltor.Models.RentViewModel> RentViewModels { get; set; }

      //  public System.Data.Entity.DbSet<Rieltor.Models.AllRentViewModel> AllRentViewModels { get; set; }

        // public System.Data.Entity.DbSet<Rieltor.Models.RentViewModel> RentViewModels { get; set; }
    }
}