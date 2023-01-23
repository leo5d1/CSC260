namespace VideoGameLibrary.Models
{
	public class Games
	{
		private static int nextID = 0;
		public int? Id { get; set; } = nextID++;
		public string Title { get; set; } = "[NO TITLE]";
		public string Platform { get; set; } = "[NO PLATFORM]";
		public string Genre { get; set; }
		public string ESRB { get; set; }
		public int Year { get; set; } = 1958;
		public string Image { get; set; }
		public string? LoanedTo { get; set; } = null;
		public string? LoanDate { get; set; } = null;

		public Games(string title, string platform, string genre, string rating, int year, string image)
		{
			Title = title;
			Platform = platform;
			Genre = genre;
			ESRB = rating;
			Year = year;
			Image = image;
		}

		public Games(int? id, string title, string platform, string genre, string rating, int year, string image)
		{
			Id = id;
			Title = title;
			Platform = platform;
			Genre = genre;
			ESRB = rating;
			Year = year;
			Image = image;
		}
	}
}
