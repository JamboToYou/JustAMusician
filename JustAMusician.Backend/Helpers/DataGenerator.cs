using System;
using System.Collections.Generic;
using System.IO;
using JustAMusician.Backend.Entities;

namespace JustAMusician.Backend.Helpers
{
	public static class DataGenerator
	{
		private const string genresFile = "/genres.txt";
		private const string instrumentsFile = "instruments.txt";
		private static string resPath;

		public static void SetupPaths(string path)
		{
			resPath = path;
		}

		public static void Generate(DataBaseContext db)
		{
			GenerateGenres(db);
			GenerateInstruments(db);
		}

		private static void GenerateInstruments(DataBaseContext db)
		{
			string name;

			using (var fs = new FileStream($@"{resPath}/{instrumentsFile}", FileMode.Open))
			using (var reader = new StreamReader(fs))
			{
				while (!reader.EndOfStream)
				{
					name = reader.ReadLine();
					db.Instruments.Add(new Instrument { Name = name, Type = null });
				}
			}

			db.SaveChanges();
		}

		public static void GenerateGenres(DataBaseContext db)
		{
			int lvl;
			string genre;
			Genre current = null;
			var parents = new Stack<Genre>();
			parents.Push(null);

			using (var fs = new FileStream($@"{resPath}/{genresFile}", FileMode.Open))
			using (var reader = new StreamReader(fs))
			{
				while (!reader.EndOfStream)
				{
					(genre, lvl) = NormalizeGenreEntry(reader.ReadLine());

					if (lvl > parents.Count)
						parents.Push(current);
					while (lvl < parents.Count)
						parents.Pop();

					current = new Genre { Title = genre, ParentGenre = parents.Peek() };
					db.Add(current);
					db.SaveChanges();
				}
			}
		}

		private static (string, int) NormalizeGenreEntry(string entry)
		{
			if (string.IsNullOrWhiteSpace(entry))
				return (null, 0);

			var cnt = 0;
			var chars = entry.ToCharArray();

			for (; cnt < chars.Length; cnt++)
			{
				if (chars[cnt] != '\t')
					break;
			}

			return (entry.Trim(), cnt + 1);
		}
	}
}