using VideoGameLibrary.Models;
using VideoGameLibrary.Interfaces;

namespace VideoGameLibrary.Data
{
	public class GamesListDAL : IDataAccessLayer
	{
		private VideoGameDBContext db;

		public GamesListDAL(VideoGameDBContext indb)
		{
			db = indb;
		}

		public void AddGame(Games game)
		{
			//GameLibrary.Add(game);
			db.Games.Add(game);
			db.SaveChanges();
		}

		public void EditGame(Games game)
		{
			//throw new NotImplementedException();
			db.Games.Update(game);
			db.SaveChanges();
		}

		public Games SearchForGames(int? id)
		{
			return db.Games.Where(m => m.Id == id).FirstOrDefault();
		}

		public IEnumerable<Games> GetCollection()
		{
			//return GameLibrary;
			return db.Games.OrderBy(m => m.Id).ToList();
		}

		public void RemoveGame(int? id)
		{
			Games targetGame = SearchForGames(id);
			//GameLibrary.Remove(game);
			db.Games.Remove(targetGame);
			db.SaveChanges();
		}

		public IEnumerable<Games> Filter(string genre, string platform, string rating)
		{
			if (genre == null) genre = "";

			if (rating == null) rating = "";

			if (rating == null) platform = "";

			if (genre == "" && rating == "" && platform == "") return SearchForGames();

			IEnumerable<Games> games1 = SearchForGames().Where(m => (!string.IsNullOrEmpty(m.Genre) && m.Genre.ToLower().Contains(genre.ToLower()))).ToList();

			IEnumerable<Games> games2 = games1.Where(m => (!string.IsNullOrEmpty(m.ESRB) && m.ESRB.ToLower().Equals(rating.ToLower()))).ToList();

			IEnumerable<Games> games3 = games2.Where(m => (!string.IsNullOrEmpty(m.Platform) && m.Platform.ToLower().Equals(platform.ToLower()))).ToList();

			if (games2.Count() == 0 && games3.Count() == 0) return games1;

			if (games2.Count() != 0 && games3.Count() == 0) return games2;

			return games3;

		}
	}
}
