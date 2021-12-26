using DirectList.Data;
using DirectList.Models;
using DirectList.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DirectList.Controllers
{
    public class HomeController : Controller
    {

        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.Name= "Home";
            VmHome model = new VmHome()
            {
                Setting = _context.Settings.FirstOrDefault(),
                Socials =_context.Socials.ToList(),
                Restaurants=_context.Restaurants.ToList(),
                Blogs=_context.Blogs.ToList(),
                DreamPlans =_context.DreamPlans.ToList()
            };
            return View(model);
        }

       
    }
}
