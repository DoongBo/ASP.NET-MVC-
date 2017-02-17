using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Razor.Models;

namespace Razor.Controllers
{
    public class HomeController : Controller
    {
        Product myproduct = new Product
        {
            Name = "Kayak",
            Price = 275M,
            IntProductID = 1,
            Category = "Watersports",
            Description = "A boat for one person"
        };
        // GET: Home
        public ActionResult Index()
        {
            return View(myproduct);
        }
        public ActionResult NameAndPrice()
        {
            return View(myproduct);
        }
        public ActionResult DemoExpression()
        {
            ViewBag.ProductCount = 1;
            ViewBag.ExpressShip = true;
            ViewBag.ApplyDiscount = false;
            ViewBag.Supplier = null;
            return View(myproduct);
        }
        public ActionResult DemoArray()
        {
            Product[] arry ={
                               new Product{Name="Kayak",Price=275M},
                               new Product{Name="LifeTackt",Price=48.95M},
                               new Product{Name="Soccer",Price=19.50M},
                               new Product{Name="Corner flag",Price=34.95M}
                           };
            return View(arry);
        }
    }
}
