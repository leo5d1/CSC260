using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Movies.Models;

namespace Movies.Controllers
{
    public class HomeController : Controller
    {
        private static int intCount = 0;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy(string pizza)
        {
            ViewBag.mypizza = pizza;
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Future()
        {
            return View();
        }

		public IActionResult RouteTest()
		{
			return Content("RouteTest stuff");
			//return Content($"id= {id?.ToString() ?? "NULL"}");
		}

		public IActionResult Counter()
        {
            ViewBag.Count = intCount++;
            return View();
        }
        
        public IActionResult ParamTest(int? id)
        {
            //return Content("stuff");
            return Content($"id= {id?.ToString() ?? "NULL"}");

        }

		public IActionResult Input()
		{
            ViewData["Title"] = "Input Form";
			return View();
            // return Redirect("https://stackoverflow.com");
            // return Redirect("/Home/Privacy");
		}

		public IActionResult Output(string FirstName, string LastName)
		{
            ViewBag.FN = FirstName;
            ViewBag.LN = LastName;
			return View("Output");
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}