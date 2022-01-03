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
    public class MenuController : Controller
    {
        private readonly AppDbContext _context;

        public MenuController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Menus.ToList());
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(Menu model)
        {
            _context.Menus.Add(model);
            _context.SaveChanges();


            return RedirectToAction("Index");
        }


        public IActionResult Update(int? id)
        {
            Menu model = _context.Menus.Find(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(Menu model)
        {
            if (ModelState.IsValid)
            {
                _context.Menus.Update(model);
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

            Menu menu = _context.Menus.Find(id);
            if (menu == null)
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

            _context.Menus.Remove(menu);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
