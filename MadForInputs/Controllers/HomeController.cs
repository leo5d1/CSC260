using System.Diagnostics;
using MadForInputs.Models;
using Microsoft.AspNetCore.Mvc;

namespace MadForInputs.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult MadLibs(string Adjective, string Noun1, string Verb, string Adverb, string Noun2)
		{
			ViewBag.AD = Adjective;
			ViewBag.N1 = Noun1;
			ViewBag.VB = Verb;
			ViewBag.AB = Adverb;
			ViewBag.N2 = Noun2;

			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}