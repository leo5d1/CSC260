using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VideoGameLibrary.Data;
using VideoGameLibrary.Interfaces;
using VideoGameLibrary.Models;

namespace VideoGameLibrary.Controllers
{
    public class HomeController : Controller
    {
		private readonly ILogger<HomeController> _logger;

		IDataAccessLayer dal = new GamesListDAL();

		public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Library()
        {
            return View(dal);
        }

		[HttpGet] //Edit form loads
		public IActionResult Edit(int? id)
		{
			Games foundGame = dal.SearchForGames(id);

			if (foundGame == null)
			{
				TempData["Error"] = "Game not found";
			}

			return View(foundGame);
		}

		[HttpPost] //save
		public IActionResult Edit(Games m)
		{
			dal.EditGame(m);
			TempData["success"] = "Game '" + m.Title + "' updated";
			return RedirectToAction("Library", "Home");
		}

		[HttpGet] //Create form loads
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost] //Create form saves
		public IActionResult Create(Games m)
		{
			if (ModelState.IsValid)
			{
				dal.AddGame(m);
				TempData["success"] = "Game added";
				return RedirectToAction("Library", "Home");
			}
			else
				return View();
		}

		public IActionResult Delete(int? id)
		{
			dal.RemoveGame(id);
			return RedirectToAction("Library", "Home");

		}

		[HttpPost]
		public IActionResult Search(string key)
		{
			if (string.IsNullOrEmpty(key))
			{
				return View("Library", dal.GetCollection());
			}
			return View("Library", dal.GetCollection().Where(x => x.Title.ToLower().Contains(key.ToLower())));
		}

		[HttpGet]
		public IActionResult Loan()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Loan(string title, string loanedTo, string loanDate)
		{
            if(title != null)
            {
				LoanedGame(dal, title, loanedTo, loanDate);
				TempData["success"] = "Game Loaned";
				return RedirectToAction("Library");
			}
			return View();
		}

		[HttpGet]
		public IActionResult Return()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Return(string title)
		{
			if (title != null)
			{
				ReturnGame(dal, title);
				TempData["success"] = "Game Returned";
				return RedirectToAction("Library");
			}
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

		public void LoanedGame(IDataAccessLayer games, string title, string name, string date)
		{
			foreach (Games g in games.GetCollection())
			{
				if (g.Title == title)
				{
					g.LoanedTo = name;
					g.LoanDate = date;
				}
			}
		}

		public void ReturnGame(IDataAccessLayer games, string title)
		{
			foreach (Games g in games.GetCollection())
			{
				if (g.Title == title)
				{
					g.LoanedTo = null;
					g.LoanDate = null;
				}
			}
		}
	}
}