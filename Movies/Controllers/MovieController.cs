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

		[HttpGet] // loading Edit page
		public IActionResult Edit(int? id)
		{
            if (id == null) return NotFound();

			Movie foundMovie = MovieList.Where(m => m.Id == id).FirstOrDefault();

			if (foundMovie == null) return NotFound();

            return View(foundMovie);
		}

        [HttpPost]
        public IActionResult Edit(Movie m)
        {
            int i;
            i = MovieList.FindIndex(x => x.Id == m.Id);
            MovieList[i] = m;
            TempData["success"] = "Movie " + m.Title + " updated";
			return RedirectToAction("MultMovies", "Movie");
		}

		[HttpGet] // loading Edit page
		public IActionResult Delete(int? id)
		{
			if (id == null) return NotFound();

			Movie foundMovie = MovieList.Where(m => m.Id == id).FirstOrDefault();

			if (foundMovie == null) return NotFound();

			return View(foundMovie);
		}

		[HttpPost]
		public IActionResult Delete(Movie m)
		{
            int i = (int) m.Id;
            MovieList.RemoveAt(i);
			TempData["success"] = "Movie " + m.Title + " deleted";
			return RedirectToAction("MultMovies", "Movie");
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
