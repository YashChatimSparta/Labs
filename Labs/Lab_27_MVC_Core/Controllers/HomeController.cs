using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lab_27_MVC_Core.Models;

namespace Lab_27_MVC_Core.Controllers
{
    public class HomeController : Controller
    {
        public static List<string> MyList = new List<string>();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult MyAction()
        {
            ViewBag.MyItem = "Data";
            ViewData["AnotherItem"] = "Another data";
            return View();
        }

        public IActionResult MyListAction()
        {
            MyList = new List<string>() { "Yash", "Sanjay", "Chatim" };
            ViewBag.MyList = MyList;
            return View(MyList);
        }
    }
}
