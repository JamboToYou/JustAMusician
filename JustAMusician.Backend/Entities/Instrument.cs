using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JustAMusician.Backend.Entities
{
	[Table("instruments")]
	public class Instrument
	{
		[Key]
		[Column("instrumentId")]
		public int InstrumentId { get; set; }

		[Required]
		[DataType(DataType.Text)]
		[Column("name")]
		public string Name { get; set; }

		public InstrumentType Type { get; set; }
	}
}