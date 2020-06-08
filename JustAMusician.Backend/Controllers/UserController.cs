using System.Linq;
using JustAMusician.Backend.Entities.ResponseModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JustAMusician.Backend.Controllers
{
	[EnableCors("AllowCors")]
	[Route("api/user")]
	public class UserController : Controller
	{
		private readonly DataBaseContext dbContext;

		public UserController(DataBaseContext db)
		{
			dbContext = db;
		}

		[Route("check")]
		[HttpGet]
		[Authorize]
		public IActionResult Get()
		{
			return Ok();
		}

		[Route("get")]
		[HttpGet]
		[Authorize]
		public IActionResult GetUser()
		{
			var user = dbContext.Users.Find(int.Parse(User.Identity.Name));

			if (user == null)
				return NotFound();

			var bands = dbContext.Bands
				.Include(band => band.UserBands)
				.ThenInclude(ub => ub.User)
				.Where(band => band.UserBands.Any(ub => ub.UserId == user.UserId))
				.Include(band => band.Leader)
				.Select(band => new BandResponseModelShort(band))
				.ToList();

			var genres = dbContext.Genres
				.Include(genre => genre.UserGenres)
				.ThenInclude(ug => ug.User)
				.Where(genre => genre.UserGenres.Any(ug => ug.UserId == user.UserId))
				.Select(genre => genre.Title)
				.ToList();

			var instruments = dbContext.Instruments
				.Include(instrument => instrument.UserInstruments)
				.ThenInclude(ui => ui.User)
				.Where(instrument => instrument.UserInstruments.Any(ui => ui.UserId == user.UserId))
				.Select(instrument => instrument.Name)
				.ToList();

			var links = dbContext.Links
				.Where(link => link.UserId == user.UserId)
				.Select(link => link.Url)
				.ToList();

			return Ok(new UserResponseModel (user)
			{
				Bands = bands,
				Genres = genres,
				Instruments = instruments,
				Links = links
			});
		}
	}
}
