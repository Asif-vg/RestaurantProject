using DirectList.Data;
using DirectList.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DirectList.Areas.admin.Controllers
{
    [Area("admin")]
    public class MenuRestaurantController : Controller
    {
        private readonly AppDbContext _context;

        public MenuRestaurantController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<MenuToRestaurant> mr = _context.MenuToRestaurants.Include(m=> m.Menu).Include(r => r.Restaurant).ToList(); 
            return View(mr);
        }

        public IActionResult Create()
        {
            ViewBag.Restaurant = _context.Restaurants.ToList();
            ViewBag.Menu = _context.Menus.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(MenuToRestaurant model)
        {

            if (ModelState.IsValid)
            {
                _context.MenuToRestaurants.Add(model);
                _context.SaveChanges();

                return RedirectToAction("Index");

            }


            ViewBag.Restaurant = _context.Restaurants.ToList();
            ViewBag.Menu = _context.MenuToRestaurants.ToList();

            return View(model);
        }

        public IActionResult Update(int? id)
        {
            MenuToRestaurant model = _context.MenuToRestaurants.FirstOrDefault(b => b.Id == id);
            ViewBag.Restaurant = _context.Restaurants.ToList();
            ViewBag.Menu = _context.Menus.ToList();
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(MenuToRestaurant model)
        {
            if (ModelState.IsValid)
            {
                _context.MenuToRestaurants.Update(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
           


            return View(model);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                HttpContext.Session.SetString("NullIdError", "Id can not be null");
                return RedirectToAction("Index");
            }

            MenuToRestaurant menuToRestaurant = _context.MenuToRestaurants.Find(id);
            if (menuToRestaurant == null)
            {
                HttpContext.Session.SetString("NullDataError", "Can not found the data");
                return RedirectToAction("Index");
            }




            _context.MenuToRestaurants.Remove(menuToRestaurant);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
