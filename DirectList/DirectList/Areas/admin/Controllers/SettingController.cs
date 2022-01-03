using DirectList.Data;
using DirectList.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DirectList.Areas.admin.Controllers
{
    [Area("admin")]
    public class SettingController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public SettingController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View(_context.Settings.FirstOrDefault());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Setting model)
        {
            if (ModelState.IsValid)
            {
                if (model.LogoFile != null)
                {
                    if (model.LogoFile.ContentType == "image/jpeg" || model.LogoFile.ContentType == "image/png")
                    {
                        if (model.LogoFile.Length < 2097152)
                        {
                            _context.Settings.Add(model);
                            _context.SaveChanges();
                            return RedirectToAction("Index");

                        }
                        else
                        {
                            ModelState.AddModelError("", "You can upload only less than 2 mb");
                            return View(model);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "You can upload only .jpeg, .jpg and .png");
                        return View(model);
                    }
                }
               
            }
            return View(model);
        }

        public IActionResult Update(int? id)
        {
            Setting setting = _context.Settings.FirstOrDefault(i => i.Id == id);
            return View(setting);
        }
        [HttpPost]
        public IActionResult Update(Setting model)
        {

            if (ModelState.IsValid)
            {
                if (model.LogoFile != null)
                {
                    if (model.LogoFile.ContentType == "image/jpeg" || model.LogoFile.ContentType == "image/png")
                    {
                        if (model.LogoFile.Length < 2097152)
                        {
                            _context.Settings.Update(model);
                            _context.SaveChanges();
                            return RedirectToAction("Index");

                        }
                        else
                        {
                            ModelState.AddModelError("", "You can upload only less than 2 mb");
                            return View(model);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "You can upload only .jpeg, .jpg and .png");
                        return View(model);
                    }
                }
             
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

            Setting setting = _context.Settings.Find(id);
            if (setting == null)
            {
                HttpContext.Session.SetString("NullDataError", "Can not found the data");
                return RedirectToAction("Index");
            }




            if (!string.IsNullOrEmpty(setting.Logo))
            {
                string oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", setting.Logo);
                if (System.IO.File.Exists(oldImagePath))
                {
                    System.IO.File.Delete(oldImagePath);
                }
            }

            _context.Settings.Remove(setting);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
