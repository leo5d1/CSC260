using VideoGameLibrary.Models;

namespace VideoGameLibrary.Interfaces
{
	public interface IDataAccessLayer
	{
		IEnumerable<Games> GetCollection();

		void AddGame(Games game);

		void RemoveGame(int? id);

		Games SearchForGames(int? id);

		void EditGame(Games game);
	}
}
