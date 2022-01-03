using DirectList.Data;
using DirectList.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

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
            VmContact model = new VmContact()
            {
                Setting = _context.Settings.FirstOrDefault(),
                Socials = _context.Socials.ToList(),
                Banner=_context.Banner.FirstOrDefault(b=>b.Page=="Contact")
            };
            return View(model);
        }
        public IActionResult Message()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Message(VmContact model)
        {
            if (ModelState.IsValid)
            {
                model.Contact.CreatedDate = DateTime.Now;
                _context.Contacts.Add(model.Contact);
                _context.SaveChanges();
                return RedirectToAction("Index");

            }
            VmContact model1 = new VmContact()
            {
                Setting = _context.Settings.FirstOrDefault(),
                Socials = _context.Socials.ToList()
            };

            return View("Index", model1);
        }
    }
}
