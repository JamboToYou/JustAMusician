namespace JustAMusician.Backend.Entities.Relations
{
	public class UserInstrument
	{

		public int UserId { get; set; }
		public User User { get; set; }

		public int InstrumentId { get; set; }
		public Instrument Instrument { get; set; }
	}
}