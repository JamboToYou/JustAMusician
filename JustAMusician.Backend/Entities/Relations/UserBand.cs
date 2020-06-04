using Microsoft.EntityFrameworkCore;

namespace JustAMusician.Backend.Entities.Relations
{
	public class UserBand
	{
		public int UserId { get; set; }
		public int BandId { get; set; }

		public User User { get; set; }
		public Band Band { get; set; }
	}
}