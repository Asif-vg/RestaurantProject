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
        public IActionResult Index()
        {
            VmBlog blog = new VmBlog()
            {
                Blogs = _context.Blogs.Include(bc => bc.BlogComments).ToList(),
                Setting = _context.Settings.FirstOrDefault(),
                Socials = _context.Socials.ToList()
            };
            return View(blog);
        }

        public IActionResult Details(int id)
        {
            
            return View(_context.Blogs.Include(bc => bc.BlogComments).FirstOrDefault(p => p.Id==id));
        }
    }
}
