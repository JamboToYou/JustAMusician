using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using JustAMusician.Backend.Entities;
using Microsoft.AspNetCore.Cors;
using JustAMusician.Backend.Entities.ViewModels;
using Microsoft.AspNetCore.Authorization;
using JustAMusician.Backend.Entities.Relations;

namespace JustAMusician.Backend.Controllers
{
	[EnableCors("AllowCors")]
	[Authorize]
	[Route("api/order")]
	public class OrderController : Controller
	{
		private readonly DataBaseContext dbContext;
		public OrderController(DataBaseContext dbContext)
		{
			this.dbContext = dbContext;
		}

		[Route("init")]
		[HttpGet]
		public ActionResult<string> Init()
		{
			// DataGenerator.SetupPaths(Directory.GetCurrentDirectory() + "/wwwroot");
			// DataGenerator.Generate(dbContext);

			// return dbContext.Genres;
			return "HelloWorld";
		}

		// GET api/values
		[Route("all")]
		[HttpGet]
		public ActionResult<IEnumerable<Order>> Get()
		{
			return dbContext.Orders.ToArray();
		}

		[HttpGet("{id}")]
		public ActionResult<string> Get(int id)
		{
			return "value";
		}

		[HttpPost]
		public IActionResult Post([FromBody] OrderViewModel vModel)
		{
			try
			{
				var order = new Order {
					Title = vModel.Title,
					Body = vModel.Body,
					ForBand = vModel.ForBand,
					CreatedAt = DateTime.Now,
					UpdatedAt = DateTime.Now,
					OwnerId = int.Parse(User.Identity.Name)
				};

				dbContext.Orders.Add(order);
				dbContext.SaveChanges();

				var genres = dbContext.Genres
					.Where(genre => vModel.Genres
						.Select(id => int.Parse(id))
						.Contains(genre.GenreId));
				
				var instruments = dbContext.Instruments
					.Where(instrument => vModel.Instruments
						.Select(id => int.Parse(id))
						.Contains(instrument.InstrumentId));

				order.OrderGenres = genres
						.Select(genre =>
							new OrderGenre { OrderId = order.OrderId, GenreId = genre.GenreId } )
						.ToList();
				
				order.OrderInstruments = instruments
						.Select(instrument =>
							new OrderInstrument { OrderId = order.OrderId, InstrumentId = instrument.InstrumentId })
						.ToList();
				dbContext.SaveChanges();
				return Ok();
			}
			catch (Exception)
			{
				return BadRequest();
			}
		}

		[Route("{id}")]
		[HttpPut]
		public IActionResult Put(int id, [FromBody] OrderViewModel vModel)
		{
			try
			{
				var order = dbContext.Orders.FirstOrDefault(odr => odr.OrderId == id);

				if (order == null || int.Parse(User.Identity.Name) != order.OwnerId)
					return BadRequest();

				order.Title = vModel.Title;
				order.Body = vModel.Body;
				order.ForBand = vModel.ForBand;

				var genres = dbContext.Genres
					.Where(genre => vModel.Genres
						.Select(oid => int.Parse(oid))
						.Contains(genre.GenreId));
				
				var instruments = dbContext.Instruments
					.Where(instrument => vModel.Instruments
						.Select(oid => int.Parse(oid))
						.Contains(instrument.InstrumentId));

				order.OrderGenres = genres
						.Select(genre =>
							new OrderGenre
							{
								OrderId = order.OrderId,
								GenreId = genre.GenreId
							}).ToList();
				
				order.OrderInstruments = instruments
						.Select(instrument =>
							new OrderInstrument
							{
								OrderId = order.OrderId,
								InstrumentId = instrument.InstrumentId
							}).ToList();

				dbContext.SaveChanges();
				return Ok();
			}
			catch (Exception)
			{
				return BadRequest();
			}
		}

		[Route("{id}")]
		[HttpDelete]
		public IActionResult Delete(int id)
		{
			try
			{
				var order = dbContext.Orders.FirstOrDefault(odr => odr.OrderId == id);
				dbContext.Orders.Remove(order);
				dbContext.SaveChanges();
				return Ok();
			}
			catch (Exception)
			{
				return BadRequest();
			}
		}
	}
}
