using Movies.Models;

namespace Movies.Interfaces
{
	public interface IDataAccessLayer
	{
		IEnumerable<Movie> GetMovies();
		void AddMovie(Movie movie);

		void RemoveMovie(int? id);

		Movie GetMovie(int? id);

		void EditMovie(Movie movie);
	}
}
