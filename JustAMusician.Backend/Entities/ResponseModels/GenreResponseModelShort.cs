namespace JustAMusician.Backend.Entities.ResponseModels
{
	public class GenreResponseModelShort
	{
		public int GenreId { get; set; }
		public string Title { get; set; }

		public GenreResponseModelShort(Genre genre)
		{
			GenreId = genre.GenreId;
			Title = genre.Title;
		}
	}
}