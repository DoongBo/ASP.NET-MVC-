using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LanguageFeatures.Models;

namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public string Index()
        {
            return "Navigate to a URL to show an example";
        }
        //
        public ViewResult AutoProperty()
        {
            Product myProduct = new Product();
            myProduct.Name = "kayak";
            myProduct.Category = "Soccer";
            myProduct.Description = "description";
            string productName = myProduct.Name;
            return View("Result",(object)String.Format("Product name:{0}",productName));
        }
        //
        public ViewResult CreateProduct()
        {
            Product myProduct = new Product { ProductID = 100, Name = "kayak", Description = "a boat for one person", Price = 275M, Category = "Watersports" };
            return View("Result", (object)String.Format("Category:{0}",myProduct.Category));
        }
        //使用类的扩展方法计算总价
        public ViewResult UseExtension()
        {
            ShoppingCart cart = new ShoppingCart
            {
                Products = new List<Product>{
                    new Product{Name="kayak",Price=275M},
                    new Product{Name="LifeJack",Price=48.95M},
                    new Product{Name="Soccer",Price=19.58M},
                    new Product{Name="Corner",Price=34.95M}
                }
            };
            decimal cartTotal = cart.TotalPrices();
            return View("Result", (object)String.Format("Total:{0:c}", cartTotal));
        }
        //使用接口的扩展方法计算总价，Array类也实现了该接口，所以数组也可以使用该扩展方法
        public ViewResult UseExtensionEnumberable()
        {
            IEnumerable<Product> products = new ShoppingCart
            {
                Products = new List<Product>{
                    new Product{Name="kayak",Price=275M},
                    new Product{Name="LifeJack",Price=48.95M},
                    new Product{Name="Soccer",Price=19.58M},
                    new Product{Name="Corner",Price=34.95M}
                }
            };
            Product[] productArry = {
                new Product{Name="kayak",Price=275M},
                    new Product{Name="LifeJack",Price=48.95M},
                    new Product{Name="Soccer",Price=19.58M},
                    new Product{Name="Corner",Price=34.95M}
            };
            
            decimal cartToatl = products.TotalPrices();
            decimal arryTotal = productArry.TotalPricesArray();
            return View("Result", (object)String.Format("Cart Total:{0},Arry Total:{1}",cartToatl,arryTotal));
        }
        //使用接口筛选扩展方法
        public ViewResult UseFilterExtensionMethod()
        {
            IEnumerable<Product> products = new ShoppingCart
            {
                Products = new List<Product>{
                    new Product{Name="kayak",Price=275M},
                    new Product{Name="LifeJack",Price=48.95M},
                    new Product{Name="Soccer",Category="Soccer",Price=19.58M},
                    new Product{Name="Corner",Category="Soccer",Price=34.95M}
                }
            };
            //Func<Product, bool> categoryFilter = delegate(Product prod)
            //{
            //    return prod.Category == "Soccer";
            //};
            Func<Product, bool> categoryFilter = prod => prod.Category == "Soccer";

            //Product[] productsArray ={
            //        new Product{Name="kayak",Price=275M},
            //        new Product{Name="LifeJack",Price=48.95M},
            //        new Product{Name="Soccer",Category="Soccer",Price=19.58M},
            //        new Product{Name="Corner",Category="Soccer",Price=34.95M}
            //};
            decimal total = 0, total1 = 0;
            foreach (Product prod in products.Filter(categoryFilter))
            {
                total += prod.Price;
            }
            //foreach (Product prod in productsArray.FileterByCategory("Soccer"))
            //    total1 += prod.Price;
            return View("Result", (object)String.Format("Total:{0},Array Total :{1}", total, total1));
        }

        //lambd表达式
        delegate int mydelegate(int x, int y);
        public string Lambd()
        {
            //定义委托
            mydelegate del = (x, y) =>  x * y ;

            string result = "";
            int total = 0;
            List<int> intlist = new List<int>{ 10, 20, 30 };
            foreach (int value in intlist)
            {
                total += del(value, value);
            }
            result = total.ToString();
            return result;
        }
       
        public ViewResult FindeProducts()
        {
            Product[] products = {
                    new Product{Name="kayak",Category="Watesports",Price=275M},
                    new Product{Name="LifeJack",Category="Watesports",Price=48.95M},
                    new Product{Name="Soccer",Category="Soccer",Price=19.58M},
                    new Product{Name="Corner",Category="Soccer",Price=34.95M}
                };
            //LINQ语句，从products查询对象并按Prcie降序排列，查询结果对象的Name属性和Price属性重新组成一个新的类型对象
            //var foundProducts = from match in products
            //                    orderby match.Price descending
            //                    select new { match.Name, match.Price };
            var foundProducts = products.OrderByDescending(e => e.Price)
                .Take(3).Select(e => new { e.Name, e.Price });
            products[2] = new Product { Name = "kayak1", Category = "Watesports", Price = 276M };
            string result = "";
            //int i = 0;
           foreach (var prod in foundProducts)
           {
               //i++;
               //if (i > 3)
               //    break;
               result += prod.Name + ":" + prod.Price + " ";
           }
            return View("Result",(object)result);
        }


    }
}