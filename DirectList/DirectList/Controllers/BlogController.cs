using DirectList.Data;
using DirectList.Models;
using DirectList.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DirectList.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;

        public BlogController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(VmSearch search)
        {
            VmBlog blog = new VmBlog()
            {
                Blogs = _context.Blogs.Include(bc => bc.BlogComments).ToList(),
                Setting = _context.Settings.FirstOrDefault(),
                Socials = _context.Socials.ToList(),
                Banner = _context.Banner.FirstOrDefault(b => b.Page == "Blog")


            };
            blog.Blogs = _context.Blogs.Include(bc => bc.BlogComments)
                                    .Where(b => (search.searchData != null ? b.Title.Contains(search.searchData) : true)).ToList();
            blog.Search = search;
            return View(blog);
        }

        public IActionResult Details(int id)
        {
            Blog blog1 = null;
            List<BlogComment> blogComments = _context.BlogComments.OrderByDescending(bc => bc.CreatedDate).Where(i => i.BlogId == id).ToList();
            if (id != null)
            {
                blog1 = _context.Blogs.Find(id);
            }
            User user = _context.Users.FirstOrDefault();
            VmBlog blog = new VmBlog()
            {
                Blog = _context.Blogs.Include(bc => bc.BlogComments).FirstOrDefault(p => p.Id == id),
                Setting = _context.Settings.FirstOrDefault(),
                Socials = _context.Socials.ToList(),
                Banner=_context.Banner.FirstOrDefault(b=>b.Page== "BlogDetail"),
                //Blog = blog1,
                BlogComments = blogComments,
                Blogs=_context.Blogs.ToList(),
                User=user

            };

            return View(blog);
        }

        

        [HttpPost]
        public IActionResult Comment(VmBlog model)
        {
            Setting setting = _context.Settings.FirstOrDefault();
            List<Social> social = _context.Socials.ToList();
            List<Blog> blog = _context.Blogs.ToList();


            VmBlog vmblog = new VmBlog()
            {
                Socials = social,
                Setting = setting,
                BlogComment = model.BlogComment,
                Blog = model.Blog,
                Blogs = blog
            };


            if (ModelState.IsValid)
            {
                model.BlogComment.CreatedDate = DateTime.Now;
                _context.BlogComments.Add(model.BlogComment);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("Index", vmblog);
        }
    }
}
