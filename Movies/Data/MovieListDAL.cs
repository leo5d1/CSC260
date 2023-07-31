using Movies.Models;
using Movies.Interfaces;

namespace Movies.Data
{
	public class MovieListDAL : IDataAccessLayer
	{
		//moved from controller
		private static List<Movie> MovieList = new List<Movie>
		{
			new Movie("Hunger Games", 2012, 4.5f),
			new Movie("Saving Private Ryan", 1998, 5f),
			new Movie("Wakanda Forever", 2022, 4.7f)
		};


		public void AddMovie(Movie movie)
		{
			MovieList.Add(movie);
		}

		public void EditMovie(Movie movie)
		{
			//int i;
			//i = MovieList.FindIndex(x => x.Id == movie.Id);
			//MovieList[i] = movie;

			MovieList[MovieList.FindIndex(x => x.Id == movie.Id)] = movie;
			//Movie foundMovie = GetMovie(movie.Id);
		}

		public Movie GetMovie(int? id)
		{
			Movie foundMovie = MovieList.Where(m => m.Id == id).FirstOrDefault();
			return foundMovie;
		}

		public IEnumerable<Movie> GetMovies()
		{
			return MovieList;
		}

		public void RemoveMovie(int? id)
		{
			Movie foundMovie = GetMovie(id);
			MovieList.Remove(foundMovie);
		}
	}
}
