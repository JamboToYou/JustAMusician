using Microsoft.EntityFrameworkCore;

namespace JustAMusician.Backend.Entities.Relations
{
	public class UserGenre
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public int GenreId { get; set; }

		public User User { get; set; }
		public Genre Genre { get; set; }
	}
}