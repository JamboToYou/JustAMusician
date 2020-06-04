using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JustAMusician.Backend.Entities
{
	[Table("links")]
	public class Link
	{
		[Key]
		[Column("linkId")]
		public int LinkId { get; set; }

		[Required]
		[DataType(DataType.Url)]
		[Column("url")]
		public string Url { get; set; }
	}
}