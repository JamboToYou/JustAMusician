using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using JustAMusician.Backend.Entities;
using Microsoft.AspNetCore.Cors;
using JustAMusician.Backend.Entities.ViewModels;
using Microsoft.AspNetCore.Authorization;
using JustAMusician.Backend.Entities.Relations;
using Microsoft.EntityFrameworkCore;
using JustAMusician.Backend.Entities.ResponseModels;

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
			return Ok(dbContext.Orders
				.Include(order => order.Owner)
				.Select(order => new OrderResponseModelShort(order))
				.ToList());
		}

		[HttpGet("{id}")]
		public IActionResult Get(int id)
		{
			var order = dbContext.Orders
				.Include(o => o.OrderGenres)
				.ThenInclude(og => og.Genre)
				.Include(o => o.OrderInstruments)
				.ThenInclude(oi => oi.Instrument)
				.Include(o => o.Owner)
				.FirstOrDefault(o => o.OrderId == id);

			if (order == null)
				return BadRequest();

			return Ok(new OrderResponseModel(order));
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
