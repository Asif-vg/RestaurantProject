using DirectList.Data;
using DirectList.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DirectList.Areas.admin.Controllers
{
    [Area("admin")]
    public class ContactController : Controller
    {

        private readonly AppDbContext _context;

        public ContactController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        
    }
}
