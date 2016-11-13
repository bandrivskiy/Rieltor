using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Rieltor.Models
{
    public class Post
    {
        [Key,ForeignKey("Address")]
        public string Id { get; set; }
        public Address Address { get; set; }
        public string Flor { get; set; }
        public string AllFlor { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
        public string AllArea { get; set; }
        public string CountRoom { get; set; }
        public string LiveArea { get; set; }
        public string CookArea { get; set; }
        public string UrlSeo { get; set; }
      //  public int CountViews { get; set; }
        public ICollection<PostCategory> PostCategory { get; set; }
        public ICollection<PostViews> PostViews { get; set; }



    }

    public class PostViews
    {
        [Key]
        [Column(Order = 0)]
        public string PostId { get; set; }

        [Key]
        [Column(Order = 1)]
        public string ViewsId { get; set; }

        // public bool Checked { get; set; }
        public Post Post { get; set; }
        public Views Views { get; set; }
    }

    public class Views
    {
        public string ViewsId { get; set; }
        public string IpAddress { get; set; }
        public DateTime VisitData { get; set; }
        public ICollection<PostViews> PostViews { get; set; }
    }

    public class PostCategory
    {
        [Key]
        [Column(Order = 0)]
        public string PostId { get; set; }

        [Key]
        [Column(Order = 1)]
        public string CategoryId { get; set; }

       // public bool Checked { get; set; }
        public Post Post { get; set; }
        public Category Category { get; set; }
      
    }

    public class Category
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string UrlSeo { get; set; }
        public ICollection<PostCategory> PostCategory { get; set; }

    }

    public class Neighborhood
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string CityId { get; set; }
        [ForeignKey("CityId")]
        public City Cities { get; set; }

        public ICollection<Address> Adresses { get; set; }
    }
    public class Address
    {
        [Key]
        public string Id { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }

        public string CityId { get; set; }
        public string NeighborhoodId { get; set; }
        [ForeignKey("NeighborhoodId")]
        public Neighborhood Neighborhood { get; set; }
        [ForeignKey("CityId")]
        public City Sity { get; set; }
        public Post Post { get; set; }
    }

    public class City
    { 
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string AreaId { get; set; }
        [ForeignKey("AreaId")]
        public Area Area { get; set; }

        public ICollection<Neighborhood> Neighborhod { get; set; }


    }

    public class Area
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }

        public ICollection<City> Cities { get; set; }
    }

   
    public class AllPostViewModel
    {
        public string Id { get; set; }
        public Post Post { get; set; }
        public Address Address { get; set; }
        public City City { get; set; }
        public Neighborhood Neigh { get; set; }
        public IList<Category> PostCategory { get; set; }
        public string UrlSlug { get; set; } 
        public string Price { get; set; }
        public string Description { get; set; }
        public string CountRoom { get; set; }
        public string Flor { get; set; }
        public string AllFlor { get; set; }
        public string AllArea { get; set; }
        public string LiveArea { get; set; }
        public string CookArea { get; set; }

    }

    public class AllRentViewModel
    {
        public string Id { get; set; }
        public Post Post { get; set; }
        public Address Address { get; set; }
        public City City { get; set; }
        public Neighborhood Neigh { get; set; }
        public string CountRoom { get; set; }
        public string Flor { get; set; }
        public string AllFlor { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
        public string AllArea { get; set; }
        public string LiveArea { get; set; }
        public string CookArea { get; set; }
        public string UrlSlug { get; set; }

    }

    public class RentViewModel
    {
        public string Id { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string CityId { get; set; }
        public string NeighborhoodId { get; set; }
        public string Flor { get; set; }
        public string AllFlor { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
        public string AllArea { get; set; }
        public string CountRoom { get; set; }
        public string LiveArea { get; set; }
        public string CookArea { get; set; }
        public string UrlSeo { get; set; }
        public int CountView { get; set; }
    }
}


    
