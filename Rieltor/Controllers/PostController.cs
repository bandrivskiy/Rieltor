using Rieltor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rieltor.DAL;

namespace Rieltor.Controllers
{
    public class PostController : Controller
    {
        private PostRepository _postRepository;

        public PostController()
        {
            _postRepository = new PostRepository(new ApplicationDbContext());
        }

        public static List<AllPostViewModel> postList = new List<AllPostViewModel>();
      //  public static List<AllRentViewModel> rentList = new List<AllRentViewModel>(); 
        // GET: Post
        public ActionResult Index()
        {
            postList.Clear();

            Post();
            return View();
           
        }
        public ActionResult Post()
        {
            var posts = _postRepository.GetPosts();

            foreach ( var post in posts)
            {
                var address = _postRepository.GetAddress(post);
                var city = _postRepository.GetCity(address);
                var neib = _postRepository.GetNeighborhod(address);
                var postCategory = _postRepository.GetPostsCategories(post);
                postList.Add(new AllPostViewModel {
                    Id = post.Id,
                    Post = post,
                    Address = address,
                    City = city,
                    Neigh = neib,
                    PostCategory = postCategory,
                    Price = post.Price,
                    Description = post.Description,
                    AllArea = post.AllArea,
                    LiveArea = post.LiveArea,
                    CookArea = post.CookArea,
                    AllFlor = post.AllFlor,
                    Flor = post.Flor,
                    CountRoom = post.CountRoom
                });
            }
            
            return PartialView("Posts",postList);
        }
       
       
    }
}