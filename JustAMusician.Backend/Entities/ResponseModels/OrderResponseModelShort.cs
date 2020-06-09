using System;

namespace JustAMusician.Backend.Entities.ResponseModels
{
	public class OrderResponseModelShort
	{
		public int OrderId { get; set; }
		public string Title { get; set; }
		public string Body { get; set; }
		public DateTime CreatedAt { get; set; }
		public bool ForBand { get; set; }
		public DateTime UpdatedAt { get; set; }
		public int OwnerId { get; set; }
		public string OwnerNickname { get; set; }

		public OrderResponseModelShort(Order order)
		{
			OrderId = order.OrderId;
			Title = order.Title;
			Body = order.Body;
			CreatedAt = order.CreatedAt;
			ForBand = order.ForBand;
			UpdatedAt = order.UpdatedAt;
			OwnerId = order.OwnerId;
			OwnerNickname = order.Owner?.Nickname;
		}
	}
}