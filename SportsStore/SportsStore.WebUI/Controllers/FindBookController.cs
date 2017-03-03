using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace SportsStore.WebUI.Controllers
{
    public class FindBookController : Controller
    {
        // GET: FindBook
        public PartialViewResult Index(string ISBN="")
        {
            Book book = new Book();
            if (ISBN != "")
            {
                string html = GetHtmlSource("https://api.douban.com/v2/book/isbn/" + ISBN);
                JavaScriptSerializer js = new JavaScriptSerializer();
                book = js.Deserialize<Book>(html);

            }
            else book = null;
            return PartialView(book);
        }

        public static string GetHtmlSource(string url)
        {
            string html = "";
            try
            {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
           Stream stream = response.GetResponseStream();
           StreamReader reader = new StreamReader(stream, Encoding.GetEncoding("utf-8"));
           html = reader.ReadToEnd();
           stream.Close();
            }
            catch
            {
                html = "抱歉，没有相关书目！";
            }
           return html;
        }
        
     
    }
   public class Book
    {
        public string []author{get;set;}        //作者，字符串数组
        public string title { get; set; }       //书名
        public string publisher { get; set; }   //出版社
        public string isbn13 { get; set; }      //isbn号
        public string summary { get; set; }     //摘要
        public Pictures images { get; set; }     //图片，大、中、小url地址
        public string binding { get; set; }     //备注
        
    }
    public class Pictures
    {
        public string small { get; set; }       //小图片地址
        public string large { get; set; }       //大图片地址
        public string medium { get; set; }      //中等图片地址
    }

  
}