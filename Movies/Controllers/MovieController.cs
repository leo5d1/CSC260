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

		public IActionResult Delete(int? id)
		{
            int i;
            i = MovieList.FindIndex(x => x.Id == id);
            if (i == -1) return NotFound();
			TempData["success"] = "Movie '" + MovieList[i].Title + "' deleted";
            MovieList.RemoveAt(i);
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
            // custom validation
            if (m.Title == "The Room")
            {
                ModelState.AddModelError("CustomError", "That movie sucks");
            }

            if (ModelState.IsValid)
            {
                MovieList.Add(m);
                TempData["success"] = "Movie created";
                return RedirectToAction("MultMovies");
            }

            return View();
        }
    }
}
