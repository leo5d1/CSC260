using Microsoft.EntityFrameworkCore;
using VideoGameLibrary.Models;

namespace VideoGameLibrary.Data
{
	public class VideoGameDBContext : DbContext
	{
		public VideoGameDBContext(DbContextOptions options) : base(options)
		{

		}

		public DbSet<Games> Games { get; set; }
	}
}
