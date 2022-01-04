using DirectList.Data;
using DirectList.Models;
using DirectList.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DirectList.Controllers
{
    public class AboutController : Controller
    {

        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AboutController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            VmAbout model = new VmAbout()
            {
                Setting = _context.Settings.FirstOrDefault(),
                Socials = _context.Socials.ToList(),
                About = _context.Abouts.FirstOrDefault(),
                Steps = _context.Steps.ToList(),
                Banner = _context.Banner.FirstOrDefault(b => b.Page == "About")
            };
            return View(model);
        }

        
    }
}
