using DirectList.Data;
using DirectList.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
            return View(_context.Contacts.ToList());
        }

        public IActionResult SendMailAll()
        {
            return View(_context.Contacts.ToList());
        }

        [HttpPost]
        public IActionResult SendMailAll(string MailText)
        {
            List<Contact> message = _context.Contacts.ToList();

            foreach (var item in message)
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("quluyevasifcode@gmail.com", "Code academy p222");
                mail.To.Add(item.Email);
                mail.Body = MailText;
                mail.IsBodyHtml = true;
                mail.Subject = "Reklam";

                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Host = "smtp.gmail.com";
                smtpClient.EnableSsl = true;
                smtpClient.Port = 587;
                smtpClient.Credentials = new NetworkCredential("quluyevasifcode@gmail.com", "Codeasif123.");

                smtpClient.Send(mail);
            }

            return RedirectToAction("Index");
        }
    }
}

        
    