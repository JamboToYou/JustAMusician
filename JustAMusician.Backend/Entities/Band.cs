using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using JustAMusician.Backend.Entities.Relations;

namespace JustAMusician.Backend.Entities
{
	[Table("bands")]
	public class Band
	{

		[Key]
		[Column("bandId")]
		public int BandId { get; set; }

		[Column("leaderId")]
		public int LeaderId { get; set; }
		public User Leader { get; set; }

		[Required]
		[DataType(DataType.Text)]
		[Column("name")]
		public string Name { get; set; }

		public List<UserBand> UserBands { get; set; }
		public List<BandGenre> BandGenres { get; set; }

		public Band()
		{
			UserBands = new List<UserBand>();
			BandGenres = new List<BandGenre>();
		}
	}
}