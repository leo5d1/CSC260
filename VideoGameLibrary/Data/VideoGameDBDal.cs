namespace VideoGameLibrary.Data
{
	public class VideoGameDBDal : GamesListDAL
	{
		public VideoGameDBDal(VideoGameDBContext indb) : base(indb)
		{
		}
	}
}
