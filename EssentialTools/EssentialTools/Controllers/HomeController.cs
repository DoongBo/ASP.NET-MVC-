using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EssentialTools.Models;
using Ninject;

namespace EssentialTools.Controllers
{
    public class HomeController : Controller
    {
        private IValueCalculator calc;
        private Product[] products ={
                                       new Product{Name="Kayak",Price=275M,Category="Watersports"},
                                       new Product{Name="Lifejacket",Price=48.95M,Category="Watersports"},
                                       new Product{Name="Soccer",Price=19.50M,Category="Soccer ball"},
                                       new Product{Name="Kayak",Price=34.95M,Category="Corner flag"}
                                   };
        public HomeController(IValueCalculator calcParam,IValueCalculator calc2)
        {
            calc = calcParam;
        }
        // GET: Home
        public ActionResult Index()
        {
            ////IValueCalculator calc = new LinqValueCalculator();
            //IKernel ninjectKernel = new StandardKernel();
            //ninjectKernel.Bind<IValueCalculator>().To<LinqValueCalculator>();
            //IValueCalculator calc = ninjectKernel.Get<IValueCalculator>();

            ShoppingCart cart = new ShoppingCart(calc) { Products = products };
            decimal totalValue = cart.CalculateProductTotal();
            return View(totalValue);
        }
    }
}