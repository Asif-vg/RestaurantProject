using DirectList.Data;
using DirectList.Models;
using DirectList.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DirectList.Controllers
{
    public class HomeController : Controller
    {

        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HomeController(AppDbContext context,IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index(VmSearch search)
        {

            ViewBag.Name= "Home";
            VmHome model = new VmHome()
            {
                Setting = _context.Settings.FirstOrDefault(),
                Socials =_context.Socials.ToList(),
                Restaurants=_context.Restaurants.ToList(),
                Blogs=_context.Blogs.ToList(),
                DreamPlans =_context.DreamPlans.ToList(),
                
            };
            model.Restaurants = _context.Restaurants.Include(bc => bc.RestaurantImages)
                                                    .Include(tr => tr.TagToRestaurants).ThenInclude(t => t.Tag)
                                    .Where(b => (search.searchData != null ? b.Name.Contains(search.searchData) : true)).ToList();

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

            return View(model);
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
                List<string> cartArr= oldData.Split("-").ToList();
                if (cartArr.Any(a => a==id.ToString()))
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



        //public IActionResult Cart(VmCart model)
        //{
        //    string oldData = Request.Cookies["cart"];

        //    if (!string.IsNullOrEmpty(oldData))
        //    {
        //        List<string> dataList = oldData.Split("-").ToList();
        //        model.Restaurants = _context.Restaurants.Include(ri => ri.RestaurantImages)
        //                                         .Where(p => dataList.Any(d => d == p.Id.ToString())).ToList();
        //    }

        //    Setting setting = _context.Settings.FirstOrDefault();
        //    List<Social> social = _context.Socials.ToList();

        //    VmCart model1 = new VmCart()
        //    {
        //        Setting = setting,
        //        Socials = social
        //    };

        //    return View(model1);
        //}


    }
}
