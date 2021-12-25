using DirectList.Data;
using DirectList.Models;
using Microsoft.AspNetCore.Hosting;
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
    public class RestaurantController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public RestaurantController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<Restaurant> restaurants = _context.Restaurants
                                                               .OrderByDescending(o => o.CreatedDate)
                                                               .Include(ri => ri.RestaurantImages)
                                                               .Include(tr => tr.TagToRestaurants).ThenInclude(t => t.Tag)
                                                               .Include(fr => fr.FeatureToRestaurants).ThenInclude(f => f.RestaurantFeatures)
                                                               .Include(mr => mr.MenuToRestaurants).ThenInclude(m => m.Menu)
                                                               .ToList();
            return View(restaurants);
        }

        public IActionResult Create()
        {
            ViewBag.Feature = _context.RestaurantFeaturess.ToList();
            ViewBag.Tags = _context.Tags.ToList();
            ViewBag.Menu = _context.MenuToRestaurants.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Restaurant model)
        {
            foreach (var image in model.RestaurantImages)
            {
                if (ModelState.IsValid)
                {
                    if (image.ImageFile.ContentType == "image/jpeg" || image.ImageFile.ContentType == "image/png")
                    {
                        if (image.ImageFile.Length <= 2097152)
                        {

                            //Create Blog
                            string fileName = Guid.NewGuid() + "-" + DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + image.ImageFile.FileName;
                            string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", fileName);
                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                image.ImageFile.CopyTo(stream);
                            }

                            image.Image = fileName;

                            _context.RestaurantImages.Add(image);
                            _context.SaveChanges();


                            //Create Tag to blog
                            if (model.TagToRestaurantId != null && model.TagToRestaurantId.Count > 0)
                            {
                                foreach (var item in model.TagToRestaurantId)
                                {
                                    TagToRestaurant tagToRestaurant= new TagToRestaurant();
                                    tagToRestaurant.TagId = item;
                                    tagToRestaurant.RestaurantId = model.Id;
                                    _context.TagToRestaurants.Add(tagToRestaurant);
                                    _context.SaveChanges();
                                }
                            }

                            if (model.MenuToRestaurantId != null && model.MenuToRestaurantId.Count > 0)
                            {
                                foreach (var item in model.MenuToRestaurantId)
                                {
                                    MenuToRestaurant menuToRestaurant = new MenuToRestaurant();
                                    menuToRestaurant.MenuId = item;
                                    menuToRestaurant.RestaurantId = model.Id;
                                    _context.MenuToRestaurants.Add(menuToRestaurant);
                                    _context.SaveChanges();
                                }
                            }

                            if (model.FeatureToRestaurantId != null && model.FeatureToRestaurantId.Count > 0)
                            {
                                foreach (var item in model.FeatureToRestaurantId)
                                {
                                    FeatureToRestaurant featureToRestaurant = new FeatureToRestaurant();
                                    featureToRestaurant.FeatureId = item;
                                    featureToRestaurant.RestaurantId = model.Id;
                                    _context.FeatureToRestaurants.Add(featureToRestaurant);
                                    _context.SaveChanges();
                                }
                            }
                            return RedirectToAction("Index");

                        }
                        else
                        {
                            ModelState.AddModelError("", "You can upload only less than 2 mb.");
                            ViewBag.Feature = _context.RestaurantFeaturess.ToList();
                            ViewBag.Tags = _context.Tags.ToList();
                            ViewBag.Menu = _context.MenuToRestaurants.ToList();
                            return View(model);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "You can upload only .jpeg, .jpg and .png");
                        ViewBag.Feature = _context.RestaurantFeaturess.ToList();
                        ViewBag.Tags = _context.Tags.ToList();
                        ViewBag.Menu = _context.MenuToRestaurants.ToList();
                        return View(model);
                    }
                }
            }


            ViewBag.Feature = _context.RestaurantFeaturess.ToList();
            ViewBag.Tags = _context.Tags.ToList();
            ViewBag.Menu = _context.MenuToRestaurants.ToList();
            return View(model);
        }


        //public IActionResult Update(int? id)
        //{
        //    Blog model = _context.Blogs.Include(tb => tb.TagToBlogs).ThenInclude(t => t.Tag).FirstOrDefault(b => b.Id == id);
        //    model.TagToBlogsId = _context.TagToBlogs.Where(tb => tb.BlogId == id).Select(a => a.TagId).ToList();
        //    ViewBag.Category = _context.BlogCategories.ToList();
        //    ViewBag.Tags = _context.Tags.ToList();
        //    return View(model);
        //}

        //[HttpPost]
        //public IActionResult Update(Blog model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (model.MainImageFile != null)
        //        {
        //            if (model.MainImageFile.ContentType == "image/jpeg" || model.MainImageFile.ContentType == "image/png")
        //            {
        //                if (model.MainImageFile.Length <= 2097152)
        //                {
        //                    //Delete old image
        //                    if (!string.IsNullOrEmpty(model.MainImage))
        //                    {
        //                        string oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", model.MainImage);
        //                        if (System.IO.File.Exists(oldImagePath))
        //                        {
        //                            System.IO.File.Delete(oldImagePath);
        //                        }
        //                    }

        //                    //Create new image
        //                    string fileName = Guid.NewGuid() + "-" + DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + model.MainImageFile.FileName;
        //                    string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", fileName);
        //                    using (var stream = new FileStream(filePath, FileMode.Create))
        //                    {
        //                        model.MainImageFile.CopyTo(stream);
        //                    }

        //                    model.MainImage = fileName;
        //                }
        //                else
        //                {
        //                    ModelState.AddModelError("", "You can upload only less than 2 mb.");
        //                    ViewBag.Category = _context.BlogCategories.ToList();
        //                    ViewBag.Tags = _context.Tags.ToList();
        //                    return View(model);
        //                }
        //            }
        //            else
        //            {
        //                ModelState.AddModelError("", "You can upload only .jpeg, .jpg and .png");
        //                ViewBag.Category = _context.BlogCategories.ToList();
        //                ViewBag.Tags = _context.Tags.ToList();
        //                return View(model);
        //            }
        //        }


        //        _context.Blogs.Update(model);
        //        _context.SaveChanges();

        //        //Delete old data
        //        List<TagToBlog> tagToBlogs = _context.TagToBlogs.Where(tb => tb.BlogId == model.Id).ToList();
        //        foreach (var item in tagToBlogs)
        //        {
        //            _context.TagToBlogs.Remove(item);
        //        }
        //        _context.SaveChanges();

        //        //Create new Tag to blog
        //        if (model.TagToBlogsId != null && model.TagToBlogsId.Count > 0)
        //        {
        //            foreach (var item in model.TagToBlogsId)
        //            {
        //                TagToBlog tagToBlog = new TagToBlog();
        //                tagToBlog.TagId = item;
        //                tagToBlog.BlogId = model.Id;
        //                _context.TagToBlogs.Add(tagToBlog);
        //            }

        //            _context.SaveChanges();
        //        }
        //        return RedirectToAction("Index");

        //    }

        //    ViewBag.Category = _context.BlogCategories.ToList();
        //    ViewBag.Tags = _context.Tags.ToList();
        //    return View(model);
        //}


        //public IActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        ///
        //    }

        //    Blog blog = _context.Blogs.Find(id);

        //    if (blog == null)
        //    {
        //        ///
        //    }

        //    //Delete old image
        //    if (!string.IsNullOrEmpty(blog.MainImage))
        //    {
        //        string oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", blog.MainImage);
        //        if (System.IO.File.Exists(oldImagePath))
        //        {
        //            System.IO.File.Delete(oldImagePath);
        //        }
        //    }

        //    //List<TagToBlog> tagToBlogs = _context.TagToBlogs.Where(t=>t.BlogId==id).ToList();
        //    //foreach (var item in tagToBlogs)
        //    //{
        //    //    _context.TagToBlogs.Remove(item);
        //    //}
        //    //_context.SaveChanges();

        //    _context.Blogs.Remove(blog);
        //    _context.SaveChanges();
        //    return RedirectToAction("Index");
        //}
    }
}
