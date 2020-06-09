using System.Collections.Generic;
using System.Linq;
using JustAMusician.Backend.Entities;
using JustAMusician.Backend.Entities.ResponseModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;

namespace JustAMusician.Backend.Controllers
{
	[EnableCors("AllowCors")]
	[Authorize]
	[Route("api/genre")]
	public class GenreController : Controller
	{
		private readonly DataBaseContext dbContext;

		public GenreController(DataBaseContext db)
		{
			dbContext = db;
		}

		[Route("all")]
		[HttpGet]
		public ActionResult<IEnumerable<TreeViewResponseModel>> All()
		{
			var genres = dbContext.Genres.Include(g => g.ParentGenre).ToList();
			return genres
				.Where(g => g.ParentGenre == null)
				.Select(g => GetGenreBranch(g, genres))
				.ToList();
		}

		private TreeViewResponseModel GetGenreBranch(Genre genre, List<Genre> genres)
		{
			var result = new TreeViewResponseModel(genre);
			if (genres.Count == 0)
				return result;

			result.Children = genres
				.Where(g => g.ParentGenre != null && g.ParentGenre.GenreId == genre.GenreId)
				.Select(g => GetGenreBranch(g, genres))
				.ToList();

			return result;
		}
	}
}
