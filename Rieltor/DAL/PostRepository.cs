using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Rieltor.Models;

namespace Rieltor.DAL
{
    public class PostRepository : IPostRepository, IDisposable
    {
        private ApplicationDbContext _context;
        public PostRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Post> GetPosts()
        {
            return _context.Posts.ToList();
        }

        public Address GetAddress(Post post)
        {
            return _context.Addresses.Where(p => p.Id == post.Id).FirstOrDefault();
        }
      

        public List<City> GetCityForFilter()
        {
            return _context.Cities.Distinct().ToList();
                //_context.Cities.Where(r => r.City.Id.Any()).Select(r => r.City).Distinct().ToList();
        }
        public City GetCity(Address address)
        {
            return _context.Cities.Where(c => c.Id == address.CityId).FirstOrDefault();
        }

        public Neighborhood GetNeighborhod(Address address)
        {
            return _context.Neighborhoods.Where(n => n.Id == address.NeighborhoodId).FirstOrDefault();
        }
        public IList<Category> GetPostsCategories(Post post)
        {
            var categorIdList = _context.PostCategories.Where(p => p.PostId == post.Id).Select(p => p.CategoryId).ToList();
            List<Category> categoryList = new List<Category>();
            foreach(var categoryItem in categoryList)
            {

                categoryList.Add(_context.Categories.Where(c => c.Id == categoryItem.Id).FirstOrDefault());
            }
            return categoryList;

        }
          
   
        public Category GetCategoryById(string id)
        {
            return _context.Categories.Find(id);
        }

        public Category GetRentCategory()
        {
            return _context.Categories.Where(c => c.Name == "Rent").First();
        }
        public IList<Post> GetPostsByCategory(Category cat)
        {
            var postIdList = _context.PostCategories.Where(p => p.CategoryId == cat.Id).Select(p => p.PostId).ToList();
            List<Post> postList = new List<Post>();
            foreach(var item in postIdList)
            {
                postList.Add(_context.Posts.Where(p => p.Id == item).FirstOrDefault());
            }
            return postList;
        }
       
        public Post GetPostById(string id)
        {
            return _context.Posts.Find(id);
        }

        public Address GetAddressesById(string id)
        {
            return _context.Addresses.Find(id);
        }
        public string GetPostBySlug(string slug)
        {
            return _context.Posts.Where(x => x.UrlSeo == slug).FirstOrDefault().Id;
        }


        public void Save()
        {
            _context.SaveChanges();
        }

        #region dispose
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion dispose
    }
}