using JustAMusician.Backend.Entities.ResponseModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace JustAMusician.Backend.Controllers
{
	[EnableCors("AllowCors")]
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
			var genres = vModel.Genres.Select(genre => int.Parse(genre));
			var instruments = vModel.Instruments.Select(instrument => int.Parse(instrument));

			var orders = dbContext.Orders
				.Include(order => order.OrderGenres)
				.Include(order => order.OrderInstruments)
				.Include(order => order.Owner)
				.Where(order =>
					(order.CreatedAt <= vModel.EndDate) &&
					(order.CreatedAt >= vModel.StartDate) &&
					(order.OrderGenres.Any(og => genres.Contains(og.GenreId))) &&
					(order.OrderInstruments.Any(oi => instruments.Contains(oi.InstrumentId))))
				.Select(order => new OrderResponseModelShort(order))
				.ToList();

			return Ok(orders);
		}
	}
}