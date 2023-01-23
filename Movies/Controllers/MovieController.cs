using Microsoft.AspNetCore.Mvc;
using Movies.Models;

namespace Movies.Controllers
{
    public class MovieController : Controller
    {
        private static List<Movie> MovieList = new List<Movie>
        {
            new Movie("Lion King", 1994, 4.9f),
            new Movie("Shrek", 2001, 5),
			new Movie("The Goofy Movie", 1995, 5),
			new Movie("Megamind", 2010, 5)

		};

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DisplayMovie()
        {
            Movie m = new Movie("The Goofy Movie", 1995, 5);

            return View(m);
        }

		public IActionResult MultMovies()
		{
			return View(MovieList);
		}

        [HttpGet] // loading Create page
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost] // saving create page
        public IActionResult Create(Movie m)
        {
            if (m != null)
            {
                MovieList.Add(m);
                TempData["success"] = "Movie created";
                return RedirectToAction("MultMovies");
            }

            return View();
        }
    }
}
