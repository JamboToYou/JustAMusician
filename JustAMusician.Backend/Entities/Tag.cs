using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using JustAMusician.Backend.Entities.Relations;

namespace JustAMusician.Backend.Entities
{
	[Table("tags")]
	public class Tag
	{
		[Key]
		[Required]
		[Column("tagId")]
		public int TagId { get; set; }

		[Required]
		[DataType(DataType.Text)]
		[Column("name")]
		public string Name { get; set; }

		public List<OrderTag> OrderTags { get; set; }

		public Tag()
		{
			OrderTags = new List<OrderTag>();
		}
	}
}