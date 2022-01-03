using DirectList.Data;
using DirectList.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DirectList.Areas.admin.Controllers
{
    [Area("admin")]

    public class FeatureController : Controller
    {
        private readonly AppDbContext _context;

        public FeatureController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.RestaurantFeaturess.ToList());
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(RestaurantFeatures model)
        {
            _context.RestaurantFeaturess.Add(model);
            _context.SaveChanges();


            return RedirectToAction("Index");
        }


        public IActionResult Update(int? id)
        {
            RestaurantFeatures model = _context.RestaurantFeaturess.Find(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(RestaurantFeatures model)
        {

            if (ModelState.IsValid)
            {
                _context.RestaurantFeaturess.Update(model);
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

            RestaurantFeatures feature = _context.RestaurantFeaturess.Find(id);
            if (feature == null)
            {
                HttpContext.Session.SetString("NullDataError", "Can not found the data");
                return RedirectToAction("Index");
            }



            //List<TagToBlog> tagToBlogs = _context.TagToBlogs.Where(t=>t.BlogId==id).ToList();
            //foreach (var item in tagToBlogs)
            //{
            //    _context.TagToBlogs.Remove(item);
            //}
            //_context.SaveChanges();

            _context.RestaurantFeaturess.Remove(feature);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
