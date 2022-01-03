using DirectList.Data;
using DirectList.Models;
using DirectList.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DirectList.Controllers
{
    public class RestaurantController : Controller
    {

        private readonly AppDbContext _context;

        public RestaurantController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(VmSearch search)
        {
            List<Restaurant> restaurants = _context.Restaurants.Include(ri=> ri.RestaurantImages)
                                                            .Include(tr => tr.TagToRestaurants).ThenInclude(t => t.Tag)
                                                           .Include(fr => fr.FeatureToRestaurants).ThenInclude(f => f.RestaurantFeatures)
                                                           .Include(mr => mr.MenuToRestaurants).ThenInclude(m => m.Menu)
                                                           .Include(rc=> rc.RestaurantComments)
                                                         .ToList();


            string oldData = Request.Cookies["cart"];

            List<string> cartList = null;

            if (!string.IsNullOrEmpty(oldData))
            {
                cartList = oldData.Split("-").ToList();
            }

            List<Restaurant> restaurants1 = new List<Restaurant>();

            if (cartList != null)
            {
                foreach (var item in cartList)
                {
                    Restaurant restaurant = _context.Restaurants.FirstOrDefault(i => i.Id.ToString() == item);

                    if (restaurant != null)
                    {
                        restaurants1.Add(restaurant);
                    }
                }
            }

            VmRestaurant vmRestaurant = new VmRestaurant()
            {
                Socials = _context.Socials.ToList(),
                Setting=_context.Settings.FirstOrDefault(),
                Restaurants=restaurants,
                Banner=_context.Banner.FirstOrDefault(b=>b.Page=="Restaurant"),
            };
            vmRestaurant.Restaurants = _context.Restaurants.Include(bc => bc.RestaurantImages)
                                    .Where(b => (search.searchData != null ? b.Name.Contains(search.searchData) : true)).ToList();
            return View(vmRestaurant);
        }

        public IActionResult Details(int? id)
        {
            Restaurant restaurant1 = null;
            List<RestaurantComment> restaurantComments = _context.RestaurantComments.OrderByDescending(bc => bc.CreatedDate).Where(i => i.RestaurantId == id).ToList();
            if (id != null)
            {
                restaurant1 = _context.Restaurants.Find(id);
            }
           

            Setting setting =  _context.Settings.FirstOrDefault();
            List<Social> socials = _context.Socials.ToList();
            Restaurant restaurant = _context.Restaurants
                                                            .Include(ri => ri.RestaurantImages)
                                                            .Include(tr => tr.TagToRestaurants).ThenInclude(t => t.Tag)
                                                            .Include(fr => fr.FeatureToRestaurants).ThenInclude(f => f.RestaurantFeatures)
                                                            .Include(mr => mr.MenuToRestaurants).ThenInclude(m => m.Menu)
                                                            .Include(a => a.Adminstrators)
                                                            .Include(rc => rc.RestaurantComments)
                                                            .FirstOrDefault(i => i.Id == id);
            VmBook restaurantt = new VmBook()
            {
                Socials = socials,
                Setting = setting,
                Restaurant = restaurant,
                Banner = _context.Banner.FirstOrDefault(b => b.Page == "RestaurantDetail"),
                RestaurantComment=_context.RestaurantComments.FirstOrDefault()
            };


            return View(restaurantt);
        }

        public IActionResult Reserve()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Reserve(VmBook model)
        {
            Setting setting = _context.Settings.FirstOrDefault();
            List<Social> social = _context.Socials.ToList();

            VmBook vmBook = new VmBook()
            {
                Socials = social,
                Setting = setting
            };

            if (ModelState.IsValid)
            {
                if (DateTime.Now <= model.Book.CreatedDate)
                {

                    model.Book.RestaurantId = model.Restaurant.Id;
                    _context.Books.Add(model.Book);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {

                }
            }

            return View("Index" , model);
        }


        public IActionResult AddToCart(int? id)
        {
            string oldData = Request.Cookies["cart"];
            string newData = null;
            if (string.IsNullOrEmpty(oldData))
            {
                newData = id.ToString();
            }
            else
            {
                List<string> cartArr = oldData.Split("-").ToList();
                if (cartArr.Any(a => a == id.ToString()))
                {
                    cartArr.Remove(id.ToString());
                    newData = string.Join("-", cartArr);
                }
                else
                {
                    newData = oldData + "-" + id;
                }
            }

            CookieOptions options = new CookieOptions()
            {
                Expires = DateTime.Now.AddYears(1)
            };
            Response.Cookies.Append("cart", newData, options);

            return RedirectToAction("Index");

        }

        [HttpPost]
        public IActionResult Comment(VmRestaurant model)
        {
            Setting setting = _context.Settings.FirstOrDefault();
            List<Social> social = _context.Socials.ToList();
            List<Restaurant> restaurants = _context.Restaurants.ToList();


            VmRestaurant vmRestaurant = new VmRestaurant()
            {
                Socials = social,
                Setting = setting,
                RestaurantComment = model.RestaurantComment,
                Restaurant = model.Restaurant,
                Restaurants = restaurants
            };


            if (ModelState.IsValid)
            {
                model.RestaurantComment.CreatedDate = DateTime.Now;
                _context.RestaurantComments.Add(model.RestaurantComment);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("Index", vmRestaurant);
        }
    }
}
