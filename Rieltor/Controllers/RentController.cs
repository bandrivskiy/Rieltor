using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Rieltor.DAL;
using PagedList;
using System.Web.Mvc;
using Rieltor.Models;

namespace Rieltor.Controllers
{
    public class RentController : Controller
    {
        private PostRepository _postRepository;

        public static List<AllRentViewModel> rentList = new List<AllRentViewModel>();

        public RentController()
        {
            _postRepository = new PostRepository(new ApplicationDbContext());
        }

        // GET: Rent
        public ActionResult Index(int? page, string CityId, string NeibId)
        {
            rentList.Clear();

            AllRent(page, CityId, NeibId);

            return View();
        }


        public ActionResult AllRent(int? page, string CityId, string NeibId)
        {
            rentList.Clear();


            var category = _postRepository.GetRentCategory();
            var posts = _postRepository.GetPostsByCategory(category);
            foreach (var post in posts)
            {
                var address = _postRepository.GetAddress(post);
                var city = _postRepository.GetCity(address);
                var neib = _postRepository.GetNeighborhod(address);
                rentList.Add(new AllRentViewModel
                {
                    Id = post.Id,
                    Address = address,
                    Price = post.Price,
                    Post = post,
                    City = city,
                    Neigh = neib,
                    Description = post.Description,
                    AllArea = post.AllArea,
                    LiveArea = post.LiveArea,
                    CookArea = post.CookArea,
                    AllFlor = post.AllFlor,
                    Flor = post.Flor,
                    CountRoom = post.CountRoom,
                    UrlSlug = post.UrlSeo
                    
                });

            }
            if (!String.IsNullOrEmpty(CityId))
            {
                rentList = rentList.Where(r => r.City.Id.ToLower() == CityId.ToLower()).ToList();
            }
            if (!String.IsNullOrEmpty(NeibId) && !NeibId.Equals("All"))
            {
                rentList = rentList.Where(r => r.Neigh.Id.ToLower() == NeibId.ToLower()).ToList();
            }


            int pageSize = 2;
            int pageNumber = (page ?? 1);
            return PartialView("AllRent", rentList.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Rent(string slug)
        {
            if (String.IsNullOrEmpty(slug))
            {
               return RedirectToAction("Index");
            }
            RentViewModel model = new RentViewModel();
            CounterViews countViews = new CounterViews();
             var postId = _postRepository.GetPostBySlug(slug);
            var post = _postRepository.GetPostById(postId);
            var address = _postRepository.GetAddress(post);
            var city = _postRepository.GetCity(address);
            var neib = _postRepository.GetNeighborhod(address);
            model.Id = post.Id;
            model.Street = post.Address.Street;
            model.Number = post.Address.Number;
            model.CityId = city.Id;
            model.NeighborhoodId = neib.Id;
            
            model.Flor = post.Flor;
            model.AllFlor = post.AllFlor;
            model.Price = post.Price;
            model.Description = post.Description;
            model.AllArea = post.AllArea;
            model.LiveArea = post.LiveArea;
            model.CookArea = post.CookArea;
            model.CountRoom = post.CountRoom;
            model.UrlSeo = post.UrlSeo;
            model.CountView = countViews.GetCount(post.UrlSeo);


            return View(model);
        }
        [HttpGet]
        public ActionResult Edit(string slug)
        {
            var model = CreateRentViewModel(slug);
            List<City> cities = _postRepository.GetCityForFilter();
            List<Neighborhood> naiberList = new List<Neighborhood>();
            cities.Insert(0, new City { Id = "0", Name = "Selected City" });
            ViewBag.CityId = new SelectList(cities, "Id", "Name", model.CityId);
            ViewBag.NeighborhoodId = new SelectList(naiberList, "Id", "Name", model.NeighborhoodId);

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(RentViewModel model)
        {
            
            var post = _postRepository.GetPostById(model.Id);
            var postAdress = _postRepository.GetAddressesById(model.Id);
            var postNeiber = _postRepository.GetNeighborhod(postAdress);
            var postCity = _postRepository.GetCity(postAdress);
            
            post.Price = model.Price;
            post.AllArea = model.AllArea;
            post.LiveArea = model.LiveArea;
            post.CookArea = model.CookArea;
            post.AllFlor = model.AllFlor;
            post.Flor = model.Flor;
            post.Description = model.Description;
            post.CountRoom = model.CountRoom;
            post.UrlSeo = model.UrlSeo;
           
            postAdress.Street = model.Street;
            postAdress.Number = model.Number;
            postAdress.CityId = model.CityId;
            postAdress.NeighborhoodId = model.NeighborhoodId;

            List<City> cities = _postRepository.GetCityForFilter();
            List<Neighborhood> naiberList = new List<Neighborhood>();
            cities.Insert(0, new City { Id = "0", Name = "Selected City" });
            ViewBag.CityId = new SelectList(cities, "Id", "Name");
            ViewBag.NeighborhoodId = new SelectList(naiberList, "Id", "Name");

            _postRepository.Save();

            return RedirectToAction("Rent", new { slug = model.UrlSeo });
           
        }

        #region helpmetods

        public RentViewModel CreateRentViewModel(string slug)
        {
            RentViewModel model = new RentViewModel();
            var postId = _postRepository.GetPostBySlug(slug);
            var post = _postRepository.GetPostById(postId);
            var address = _postRepository.GetAddress(post);
            var city = _postRepository.GetCity(address);
            var neib = _postRepository.GetNeighborhod(address);
            model.Id = post.Id;
            model.Street = post.Address.Street;
            model.Number = post.Address.Number;
            model.CityId = city.Id;
            model.NeighborhoodId = neib.Id;
            
            model.Flor = post.Flor;
            model.AllFlor = post.AllFlor;
            model.Price = post.Price;
            model.Description = post.Description;
            model.AllArea = post.AllArea;
            model.LiveArea = post.LiveArea;
            model.CookArea = post.CookArea;
            model.CountRoom = post.CountRoom;
            model.UrlSeo = post.UrlSeo;
            return model;
        }

        public JsonResult GetNeibById(string id)
        {
            List<Neighborhood> neiblist = new List<Neighborhood>();
            if(id != null)
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    neiblist = db.Neighborhoods.Where(n => n.CityId.Equals(id)).OrderBy(n => n.Name).ToList();
                }
            }
            else
            {
                neiblist.Insert(0, new Neighborhood { Id = "0", Name = "Selected Neighborhood" });
            }

            var result = (from r in neiblist
                          select new
                          {
                              id = r.Id,
                              name = r.Name
                          }).ToList();

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCities()
        {
            List<City> AllCities = new List<City>();
            using (ApplicationDbContext db = new ApplicationDbContext()) {
                AllCities = db.Cities.OrderBy(c => c.Name).ToList();
                    }

            return new JsonResult { Data = AllCities, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult GetNaighborhood(string cityId)
        {
            List<Neighborhood> naibList = new List<Neighborhood>();
           using(ApplicationDbContext db = new ApplicationDbContext())
            {
                naibList = db.Neighborhoods.Where(n => n.CityId.Equals(cityId)).OrderBy(n => n.Name).ToList();
            }
            return new JsonResult { Data = naibList, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        #endregion
    }
}