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
                Socials = _context.Socials.ToList()
                
            };
            blog.Blogs = _context.Blogs.Include(bc => bc.BlogComments)
                                    .Where(b => (search.searchData != null ? b.Title.Contains(search.searchData) : true)).ToList();
            blog.Search = search;
            return View(blog);
        }

        public IActionResult Details(int id)
        {
            VmDBlog blog = new VmDBlog()
            {
                Blog = _context.Blogs.Include(bc => bc.BlogComments).FirstOrDefault(p => p.Id == id),
                Setting = _context.Settings.FirstOrDefault(),
                Socials = _context.Socials.ToList()
            };

            return View(blog);
        }
    }
}
