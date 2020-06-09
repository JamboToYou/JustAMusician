using Microsoft.EntityFrameworkCore;

namespace JustAMusician.Backend.Entities.Relations
{
	public class OrderGenre
	{
		public int OrderId { get; set; }
		public int GenreId { get; set; }

		public Order Order { get; set; }
		public Genre Genre { get; set; }
	}
}