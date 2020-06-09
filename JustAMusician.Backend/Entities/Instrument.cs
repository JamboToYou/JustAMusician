using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using JustAMusician.Backend.Entities.Relations;

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

		[ForeignKey("typeId")]
		public InstrumentType Type { get; set; }
		public List<UserInstrument> UserInstruments { get; set; }
		public List<OrderInstrument> OrderInstruments { get; set; }

		public Instrument()
		{
			OrderInstruments = new List<OrderInstrument>();
			UserInstruments = new List<UserInstrument>();
		}
	}
}