using DirectList.Data;
using DirectList.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DirectList.Controllers
{
    public class RestaurantController : Controller
    {

        private readonly AppDbContext _context;

        public RestaurantController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            VmRestaurant model = new VmRestaurant()
            {
                Setting = _context.Settings.FirstOrDefault(),
                Socials = _context.Socials.ToList()
            };
            return View(model);
        }
    }
}
