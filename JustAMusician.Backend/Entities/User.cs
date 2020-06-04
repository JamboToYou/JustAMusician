using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using JustAMusician.Backend.Entities.Relations;

namespace JustAMusician.Backend.Entities
{
	[Table("users")]
	public class User
	{
		[Key]
		[Column("userId")]
		public int UserId { get; set; }


		[Required]
		[DataType(DataType.Text)]
		[Column("nickname")]
		public string Nickname { get; set; }

		[Required]
		[DataType(DataType.EmailAddress)]
		[Column("email")]
		public string Email { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[Column("passwordHash")]
		public string PasswordHash { get; set; }

		[Required]
		[MaxLength(16)]
		[Column("salt")]
		public byte[] Salt { get; set; }

		[Required]
		[DataType(DataType.MultilineText)]
		[Column("about")]
		public string About { get; set; }

		[Required]
		[DataType(DataType.DateTime)]
		[Column("signedUpAt")]
		public DateTime SignedUpAt { get; set; }

		public List<Genre> Genres { get; set; }

		public List<Instrument> Instruments { get; set; }

		public List<UserBand> UserBands { get; set; }
		public List<UserGenre> UserGenres { get; set; }

		public List<Link> Links { get; set; }

		public User()
		{
			UserBands = new List<UserBand>();
			UserGenres = new List<UserGenre>();
		}
	}
}
