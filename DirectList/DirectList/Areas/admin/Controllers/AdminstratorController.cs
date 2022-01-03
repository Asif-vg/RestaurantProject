using DirectList.Data;
using DirectList.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DirectList.Areas.admin.Controllers
{
    [Area("admin")]
    public class AdminstratorController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AdminstratorController(AppDbContext context, IWebHostEnvironment webHostEnvironment )
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            //List<Adminstrator> admin = _context.Adminstrators.Include(r=>r.Restaurant).ToList();
            return View(_context.Adminstrators.Include(r=>r.Restaurant).ToList());
        }

        public IActionResult Create()
        {
            ViewBag.Restaurant = _context.Restaurants.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Adminstrator model)
        {
            if (ModelState.IsValid)
            {
                if (model.ImageFile != null)
                {
                    if (model!=null)
                    {
                        if (model.ImageFile.ContentType == "image/jpeg" || model.ImageFile.ContentType == "image/png")
                        {
                            if (model.ImageFile.Length <= 2097152)
                            {
                                string fileName = Guid.NewGuid() + "-" + DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + model.ImageFile.FileName;
                                string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", fileName);

                                using (var stream = new FileStream(filePath, FileMode.Create))
                                {
                                    model.ImageFile.CopyTo(stream);
                                }

                                model.Image = fileName;

                                _context.Adminstrators.Add(model);
                                _context.SaveChanges();

                                return RedirectToAction("Index");
                            }
                            else
                            {
                                ViewBag.Restaurant = _context.Restaurants.ToList();
                                ModelState.AddModelError("", "You can upload only less than 2 mb");
                                return RedirectToAction("Index");
                            }
                        }
                        else
                        {
                            ViewBag.Restaurant = _context.Restaurants.ToList();
                            ModelState.AddModelError("", "You can upload only .jpeg, .jpg and .png");

                            return RedirectToAction("Index");
                        }
                    }
                }
                else
                {
                    ViewBag.Restaurants = _context.Restaurants.ToList();
                    _context.Adminstrators.Add(model);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }

                return RedirectToAction("Index");
            }


            ViewBag.Restaurants = _context.Restaurants.ToList();
            return View(model);
        }

        public IActionResult Update(int? id)
        {
            Adminstrator model = _context.Adminstrators.Find(id);
            ViewBag.Restaurant = _context.Restaurants.ToList();

            return View(model);
        }

        [HttpPost]
        public IActionResult Update(Adminstrator model)
        {
            if (ModelState.IsValid)
            {
                if (model.ImageFile != null)
                {
                    if (model.ImageFile.ContentType == "image/jpeg" || model.ImageFile.ContentType == "image/png")
                    {
                        if (model.ImageFile.Length <= 2097152)
                        {
                            if (!string.IsNullOrEmpty(model.Image))
                            {
                                string oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", model.Image);
                                if (System.IO.File.Exists(oldImagePath))
                                {
                                    System.IO.File.Delete(oldImagePath);
                                }
                            }

                            string fileName = Guid.NewGuid() + "-" + DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + model.ImageFile.FileName;
                            string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", fileName);
                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                model.ImageFile.CopyTo(stream);
                            }

                            model.Image = fileName;
                            _context.Adminstrators.Update(model);
                            _context.SaveChanges();
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            ModelState.AddModelError("", "You can upload only less than 2 mb.");
                            ViewBag.Restaurant = _context.Restaurants.ToList();

                            return View(model);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "You can upload only .jpeg, .jpg and .png");
                        ViewBag.Restaurant = _context.Restaurants.ToList();

                        return View(model);
                    }
                }

                else
                {
                    ViewBag.Restaurants = _context.Restaurants.ToList();

                    _context.Adminstrators.Update(model);
                    _context.SaveChanges();
                    return RedirectToAction("Index");

                }
            }

            ViewBag.Restaurants = _context.Restaurants.ToList();

            return View(model);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                HttpContext.Session.SetString("NullIdError", "Id can not be null");
                return RedirectToAction("Index");
            }

            Adminstrator adminstrator = _context.Adminstrators.Find(id);
            if (adminstrator == null)
            {
                HttpContext.Session.SetString("NullDataError", "Can not found the data");
                return RedirectToAction("Index");
            }




            if (!string.IsNullOrEmpty(adminstrator.Image))
            {
                string oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", adminstrator.Image);
                if (System.IO.File.Exists(oldImagePath))
                {
                    System.IO.File.Delete(oldImagePath);
                }
            }


            _context.Adminstrators.Remove(adminstrator);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
