using System.Linq;
using JustAMusician.Backend.Entities;
using JustAMusician.Backend.Entities.Relations;
using JustAMusician.Backend.Entities.ResponseModels;
using JustAMusician.Backend.Entities.ViewModels;
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

		[Route("{id}")]
		[HttpGet]
		[Authorize]
		public IActionResult Get(int id)
		{
			var user = dbContext.Users.FirstOrDefault(usr => usr.UserId == id);

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

		[Route("get")]
		[HttpGet]
		[Authorize]
		public IActionResult GetUser()
		{
			var user = dbContext.Users.FirstOrDefault(usr => usr.UserId == int.Parse(User.Identity.Name));

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

		[HttpPut]
		[Authorize]
		public IActionResult Update([FromBody] UserEditViewModel vModel)
		{
			var user = dbContext.Users
				.Include(usr => usr.UserInstruments)
				.FirstOrDefault(usr => usr.UserId == int.Parse(User.Identity.Name));
			if (user == null)
				return BadRequest();

			user.Links = vModel.Links?.Select(link => new Link { Url = link }).ToList();
			user.About = vModel.About;
			user.UserInstruments = dbContext.Instruments
				.Where(instr => vModel.Instruments
					.Select(i => int.Parse(i))
					.Contains(instr.InstrumentId))
				.Select(instr => new UserInstrument { UserId = user.UserId, InstrumentId = instr.InstrumentId })
				.ToList();

			dbContext.SaveChanges();

			return Ok();
		}
	}
}
