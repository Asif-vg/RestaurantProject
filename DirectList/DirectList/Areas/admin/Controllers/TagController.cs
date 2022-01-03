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
    public class TagController : Controller
    {
        private readonly AppDbContext _context;

        public TagController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Tags.ToList());
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(Tag model)
        {
            _context.Tags.Add(model);
            _context.SaveChanges();


            return RedirectToAction("Index");
        }


        public IActionResult Update(int? id)
        {
            Tag  model = _context.Tags.FirstOrDefault(b => b.Id == id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(Tag model)
        {
                _context.Tags.Update(model);
                _context.SaveChanges();
            

            return View(model);
        }


        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                HttpContext.Session.SetString("NullIdError", "Id can not be null");
                return RedirectToAction("Index");
            }

            Tag tag = _context.Tags.Find(id);
            if (tag == null)
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

            _context.Tags.Remove(tag);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
