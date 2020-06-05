using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using JustAMusician.Backend.Entities.Relations;

namespace JustAMusician.Backend.Entities
{
	[Table("genres")]
	public class Genre
	{
		[Key]
		[Column("genreId")]
		public int GenreId { get; set; }

		[Required]
		[DataType(DataType.Text)]
		[Column("title")]
		public string Title { get; set; }

		public List<UserGenre> UserGenres { get; set; }
		public List<BandGenre> BandGenres { get; set; }

		[ForeignKey("parentGenreId")]
		public Genre ParentGenre { get; set; }

		public Genre()
		{
			UserGenres = new List<UserGenre>();
			BandGenres = new List<BandGenre>();
		}
	}
}