using JustAMusician.Backend.Entities.ResponseModels;
using JustAMusician.Backend.Entities.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace JustAMusician.Backend.Controllers
{
	[EnableCors("AllowCors")]
	[Authorize]
	[Route("api/search")]
	public class SearchController : Controller
	{
		private readonly DataBaseContext dbContext;

		public SearchController(DataBaseContext db)
		{
			dbContext = db;
		}

		[HttpPost]
		public IActionResult Search([FromBody] SearchViewModel vModel)
		{
			var genres = vModel.Genres?.Select(genre => int.Parse(genre));
			var instruments = vModel.Instruments?.Select(instrument => int.Parse(instrument));

			var orders = dbContext.Orders
				.Include(order => order.OrderGenres)
				.Include(order => order.OrderInstruments)
				.Include(order => order.Owner)
				.Where(order =>
					(order.CreatedAt <= DateTime.Parse(vModel.EndDate)) &&
					(order.CreatedAt >= DateTime.Parse(vModel.StartDate)) &&
					(genres.Count() == 0 || order.OrderGenres.Any(og => genres.Contains(og.GenreId))) &&
					(instruments.Count() == 0 || order.OrderInstruments.Any(oi => instruments.Contains(oi.InstrumentId))))
				.Select(order => new OrderResponseModelShort(order))
				.ToList();

			return Ok(orders);
		}
	}
}