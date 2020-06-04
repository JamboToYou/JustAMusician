using JustAMusician.Backend.Entities;
using JustAMusician.Backend.Entities.Relations;
using Microsoft.EntityFrameworkCore;

namespace JustAMusician.Backend
{
	public class DataBaseContext : DbContext
	{
		public DbSet<Order> Orders { get; set; }
		public DbSet<Tag> Tags { get; set; }
		public DbSet<Genre> Genres { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<Instrument> Instruments { get; set; }
		public DbSet<InstrumentType> InstrumentTypes { get; set; }
		public DbSet<Link> Links { get; set; }

		public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) {}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			SetupUserBandRelation(builder);
			SetupUserGenreRelation(builder);
			SetupBandGenreRelation(builder);
			SetupUserInstrumentRelation(builder);
			SetupOrderTagRelation(builder);
		}

		private static void SetupUserBandRelation(ModelBuilder builder)
		{
			builder.Entity<UserBand>()
				.HasKey(t => new { t.UserId, t.BandId } );
			
			builder.Entity<UserBand>()
				.HasOne(t => t.User)
				.WithMany(t => t.UserBands)
				.HasForeignKey(t => t.UserId);
			
			builder.Entity<UserBand>()
				.HasOne(t => t.Band)
				.WithMany(t => t.UserBands)
				.HasForeignKey(t => t.BandId);
		}

		private static void SetupUserGenreRelation(ModelBuilder builder)
		{
			builder.Entity<UserGenre>()
				.HasKey(t => new { t.UserId, t.GenreId } );
			
			builder.Entity<UserGenre>()
				.HasOne(t => t.User)
				.WithMany(t => t.UserGenres)
				.HasForeignKey(t => t.UserId);
			
			builder.Entity<UserGenre>()
				.HasOne(t => t.Genre)
				.WithMany(t => t.UserGenres)
				.HasForeignKey(t => t.GenreId);
		}

		private static void SetupBandGenreRelation(ModelBuilder builder)
		{
			builder.Entity<BandGenre>()
				.HasKey(t => new { t.BandId, t.GenreId } );
			
			builder.Entity<BandGenre>()
				.HasOne(t => t.Band)
				.WithMany(t => t.BandGenres)
				.HasForeignKey(t => t.BandId);
			
			builder.Entity<BandGenre>()
				.HasOne(t => t.Genre)
				.WithMany(t => t.BandGenres)
				.HasForeignKey(t => t.GenreId);
		}

		private static void SetupUserInstrumentRelation(ModelBuilder builder)
		{
			builder.Entity<UserInstrument>()
				.HasKey(t => new { t.UserId, t.InstrumentId } );
			
			builder.Entity<UserInstrument>()
				.HasOne(t => t.User)
				.WithMany(t => t.UserInstruments)
				.HasForeignKey(t => t.UserId);
			
			builder.Entity<UserInstrument>()
				.HasOne(t => t.Instrument)
				.WithMany(t => t.UserInstruments)
				.HasForeignKey(t => t.InstrumentId);
		}

		private static void SetupOrderTagRelation(ModelBuilder builder)
		{
			builder.Entity<OrderTag>()
				.HasKey(t => new { t.OrderId, t.TagId } );
			
			builder.Entity<OrderTag>()
				.HasOne(t => t.Order)
				.WithMany(t => t.OrderTags)
				.HasForeignKey(t => t.OrderId);
			
			builder.Entity<OrderTag>()
				.HasOne(t => t.Tag)
				.WithMany(t => t.OrderTags)
				.HasForeignKey(t => t.TagId);
		}
	}
}