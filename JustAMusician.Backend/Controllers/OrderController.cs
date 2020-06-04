using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JustAMusician.Backend.Entities;
using Microsoft.AspNetCore.Cors;

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
		public string Init()
		{
			dbContext.Users.Add(new User());

			dbContext.Orders.AddRange(new Order[] {
				new Order {
					Title = "Ищем басиста",
					Body = "В панк-рок группу требуется басист. Наш основной репертуар выходит на груве басовой линии, и поэтому важен скилл",
					CreatedAt = DateTime.Now,
					UpdatedAt = DateTime.Now
				},
				new Order {
					Title = "Требуется экстрим-вокалист",
					Body = "Нужен для 3-4 студийных сессий. Материал имеется. Есть демо-записи прошлого вокалиста",
					CreatedAt = DateTime.Now,
					UpdatedAt = DateTime.Now
				},
				new Order {
					Title = "Набор гитаристов в ансамбль",
					Body = "Есть 13 мест, 7 из них на нейлоне, 4 на аккустике и 2 на баритон. Играем нео-классику",
					CreatedAt = DateTime.Now,
					UpdatedAt = DateTime.Now
				},
				new Order {
					Title = "Ищу звукача",
					Body = "Требуется на выезд. Оборудование свое. Подробности в лс",
					CreatedAt = DateTime.Now,
					UpdatedAt = DateTime.Now
				},
				new Order {
					Title = "!!!СРОЧНО!!!Басист!!!",
					Body = "Срочно!!! Ищем басиста для 4-хконцертного тура. Материал простой, так что достаточно пройти у нас небольшой кастинг. подробности по гонорару при встрече",
					CreatedAt = DateTime.Now,
					UpdatedAt = DateTime.Now
				},
				new Order {
					Title = "Это никакое не объявление",
					Body = "Здесь просто текст-наполнитель, не несет никакой смысловой нагрузки",
					CreatedAt = DateTime.Now,
					UpdatedAt = DateTime.Now
				},
			});
			dbContext.SaveChanges();
			return "done";
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
