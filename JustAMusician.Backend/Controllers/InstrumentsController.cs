using System;
using System.Collections.Generic;
using System.Linq;
using JustAMusician.Backend.Entities;
using JustAMusician.Backend.Entities.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JustAMusician.Backend.Controllers
{
	[EnableCors("AllowCors")]
	[Route("api/instrument")]
	public class InstrumentController : Controller
	{
		private readonly DataBaseContext dbContext;

		public InstrumentController(DataBaseContext db)
		{
			dbContext = db;
		}

		[Route("all")]
		[HttpGet]
		public ActionResult<IEnumerable<TreeViewModel>> All()
		{
			return dbContext.Instruments
				.GroupBy(instr => instr.Name.First())
				.ToDictionary(g => g.Key, g => g.ToList())
				.Select(gc =>
					new TreeViewModel
					{
						Value = $"{gc.Key}",
						Label = gc.Key.ToString(),
						Children = gc.Value.Select(g => new TreeViewModel
							{
								Value = $"{g.InstrumentId}",
								Label = g.Name
							}).ToList()
					}).ToList();
		}
	}
}