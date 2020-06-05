using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JustAMusician.Backend.Entities;
using Microsoft.AspNetCore.Cors;
using JustAMusician.Backend.Helpers;
using System.IO;

namespace JustAMusician.Backend.Controllers
{
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
		[EnableCors("AllowCors")]
		[Route("all")]
		[HttpGet]
		public ActionResult<IEnumerable<Order>> Get()
		{
			return dbContext.Orders.ToArray();
		}

		// GET api/values/5
		[HttpGet("test")]
		public ActionResult<string> Get(int id)
		{
			return "value";
		}

		// POST api/values
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		// PUT api/values/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/values/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
