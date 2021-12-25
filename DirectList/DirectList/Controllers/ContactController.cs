using DirectList.Data;
using DirectList.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DirectList.Controllers
{
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
        public IActionResult Message()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Message(Contact model)
        {
            if (ModelState.IsValid)
            {
                model.CreatedDate = DateTime.Now;
                _context.Contacts.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");

            }
            return View("Index", model);
        }
    }
}
