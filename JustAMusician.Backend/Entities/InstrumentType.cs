using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JustAMusician.Backend.Entities
{
	[Table("instrumentType")]
	public class InstrumentType
	{
		[Key]
		[Column("instrumentTypeId")]
		public int InstrumentTypeId { get; set; }

		[Required]
		[DataType(DataType.Text)]
		[Column("type")]
		public string Type { get; set; }
	}
}