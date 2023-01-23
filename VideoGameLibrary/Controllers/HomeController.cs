using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using VideoGameLibrary.Models;

namespace VideoGameLibrary.Controllers
{
    public class HomeController : Controller
    {
		private static List<Games> GameList = new List<Games>
		{
			new Games("The Legend of Zelda: Twilight Princess", "GameCube, Wii, Wii U", "Action-Adventure", "T - Teens", 2006, "twilightprincess.jpg"),
			new Games("Ultra Kill", "PC", "First-Person Shooter", "M - Mature", 2020, "ultrakill.jpg"),
			new Games("Spelunky", "PC, Switch, Playstation, Xbox", "Rogue-Like", "Unavailable", 2008, "Spelunky.jpg"),
			new Games("A Plague Tale: Requiem", "PC, Switch, Playstation, Xbox", "Action-Adventure", "M - Mature", 2022, "requiem.jpg"),
			new Games("Stray", "PC, Playstation", "Adventure", "E - Everyone", 2022, "stray.jpg")
		};

		private readonly ILogger<HomeController> _logger;

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
            return View(GameList);
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
				LoanedGame(GameList, title, loanedTo, loanDate);
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
				ReturnGame(GameList, title);
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

		public void LoanedGame(List<Games> games, string title, string name, string date)
		{
			foreach (Games g in games)
			{
				if (g.Title == title)
				{
					g.LoanedTo = name;
					g.LoanDate = date;
				}
			}
		}

		public void ReturnGame(List<Games> games, string title)
		{
			foreach (Games g in games)
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