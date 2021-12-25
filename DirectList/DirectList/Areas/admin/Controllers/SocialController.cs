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
    public class SocialController : Controller
    {
        private readonly AppDbContext _context;

        public SocialController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Social> social = _context.Socials.ToList();
            return View(social);
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(Social model)
        {

            _context.Socials.Add(model);
            _context.SaveChanges();

            return RedirectToAction("Index");

        }


        public IActionResult Update(int? id)
        {
            Social model = _context.Socials.FirstOrDefault(b => b.Id == id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(Social model)
        {
            

                _context.Socials.Update(model);
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

            Social social = _context.Socials.Find(id);
            if (social == null)
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

            _context.Socials.Remove(social);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
