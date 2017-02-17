using PartyInvities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PartyInvities.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ViewResult Index()
        {
           DateTime time = DateTime.Now;
           ViewBag.Greeting = time.ToString();
            return View();
        }
        [HttpGet]
        public ViewResult RsvpForm()
        {
            return View();
        }
        [HttpPost]
        public ViewResult RsvpForm(GuestRespones guestrespone)
        {
            if (ModelState.IsValid)
                return View("Thanks", guestrespone);
            else return View();
        }
    }
}