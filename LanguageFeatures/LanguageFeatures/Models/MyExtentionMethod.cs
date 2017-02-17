using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LanguageFeatures.Models
{
    public static class MyExtentionMethods
    {
        //对类ShoppingCart添加扩展方法
        //public static decimal TotalPrices(this ShoppingCart cardParam)
        //{
        //    decimal total = 0;
        //    foreach(Product prod in cardParam.Products)
        //    {
        //        total += prod.Price;
        //    }
        //    return total;
        //}
        //对接口添加扩展方法
        public static decimal TotalPrices(this IEnumerable<Product> productEnum)
        {
            decimal total = 0;
            foreach(Product prod in productEnum)
            {
                total += prod.Price;
            }
            return total;
        }
        //对Array类添加扩展方法
        public static decimal TotalPricesArray(this Array productaraay)
        {
            decimal total=0;
            foreach (Product prod in productaraay)
                total += prod.Price;
            return total;
        }
        //对接口添加筛选扩展方法
        public static IEnumerable<Product> FileterByCategory(this IEnumerable<Product> productEnum,string categoryParam)
        {
            foreach (Product prod in productEnum)
                if (prod.Category == categoryParam)
                {
                    yield return prod;
                }
        }

       //

        //
        public static IEnumerable<Product> Filter(
            this IEnumerable<Product> productEnum, Func<Product, bool> selectorParam)
        {
            foreach (Product prod in productEnum)
            {
                if(selectorParam (prod))
                    yield return prod;
            }
        }
    }
}