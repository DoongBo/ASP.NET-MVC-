using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;

namespace SportsStore.WebUI.Controllers
{
    public class NavController : Controller
    {
        private IProductRespository repository;
        public NavController(IProductRespository repo)
        {
            repository = repo;
        }
        public PartialViewResult Menu(string category=null)
        {
            ViewBag.SelectCategory = category;
            IEnumerable<string> categories = repository.Products
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);
            return PartialView("FlexMenu",categories);
        }
    }
}