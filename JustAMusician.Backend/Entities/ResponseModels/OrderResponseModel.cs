using System;
using System.Collections.Generic;
using System.Linq;

namespace JustAMusician.Backend.Entities.ResponseModels
{
	public class OrderResponseModel
	{
		public int OrderId { get; set; }
		public string Title { get; set; }
		public string Body { get; set; }
		public DateTime CreatedAt { get; set; }
		public bool ForBand { get; set; }
		public DateTime UpdatedAt { get; set; }
		public int OwnerId { get; set; }
		public User Owner { get; set; }
		public List<string> Genres { get; set; }
		public List<string> Instruments { get; set; }

		public OrderResponseModel(Order order)
		{
			OrderId = order.OrderId;
			Title = order.Title;
			Body = order.Body;
			CreatedAt = order.CreatedAt;
			ForBand = order.ForBand;
			UpdatedAt = order.UpdatedAt;
			OwnerId = order.OwnerId;
			Owner = order.Owner;
			Genres = order.OrderGenres.Select(og => og.Genre.Title).ToList();
			Instruments = order.OrderInstruments.Select(oi => oi.Instrument.Name).ToList();
		}
	}
}