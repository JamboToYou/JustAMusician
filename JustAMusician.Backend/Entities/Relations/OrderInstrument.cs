using Microsoft.EntityFrameworkCore;

namespace JustAMusician.Backend.Entities.Relations
{
	public class OrderInstrument
	{
		public int OrderId { get; set; }
		public int InstrumentId { get; set; }

		public Order Order { get; set; }
		public Instrument Instrument { get; set; }
	}
}