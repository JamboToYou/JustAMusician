using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JustAMusician.Backend.Entities;

namespace JustAMusician.Backend.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrderController : Controller
	{
		// GET api/values
		[HttpGet]
		public ActionResult<IEnumerable<OrderShort>> Get()
		{
			return new OrderShort[]
			{
				new OrderShort("Ищу басиста", "Some quick example text to build on the card title and make up the bulk of the card's content."),
				new OrderShort("Ищу носки", "Some quick example text to build on the card title and make up the bulk of the card's content."),
				new OrderShort("Требуется музыка", "Some quick example text to build on the card title and make up the bulk of the card's content."),
				new OrderShort("Требуется музыка", "Some quick example text to build on the card title and make up the bulk of the card's content."),
				new OrderShort("Ищу басиста", "Some quick example text to build on the card title and make up the bulk of the card's content."),
				new OrderShort("Ищу басиста", "Some quick example text to build on the card title and make up the bulk of the card's content."),
				new OrderShort("First", "First body body body body body body body body body body body body"),
				new OrderShort("Second", "Second body body body body body body body body body body body body")
			};

			// return new string[] { "Val1", "Val2" };
		}

		// GET api/values/5
		[HttpGet("{id}")]
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
