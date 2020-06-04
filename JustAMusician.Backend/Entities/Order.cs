using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using JustAMusician.Backend.Entities.Relations;

namespace JustAMusician.Backend.Entities
{
	[Table("orders")]
	public class Order
	{
		[Key]
		[Required]
		[Column("orderId")]
		public int OrderId { get; set; }

		[Required]
		[DataType(DataType.Text)]
		[Column("title")]
		public string Title { get; set; }

		[Required]
		[DataType(DataType.Text)]
		[Column("body")]
		public string Body { get; set; }

		[Required]
		[DataType(DataType.DateTime)]
		[Column("createdAt")]
		public DateTime? CreatedAt { get; set; }

		[Required]
		[DataType(DataType.DateTime)]
		[Column("updatedAt")]
		public DateTime UpdatedAt { get; set; }

		[Required]
		[ForeignKey("ownerId")]
		public User Owner { get; set; }

		public List<OrderTag> OrderTags { get; set; }

		public Order()
		{
			OrderTags = new List<OrderTag>();
		}
	}
}
