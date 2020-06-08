namespace JustAMusician.Backend.Entities.ResponseModels
{
	public class InstrumentResponseModel
	{
		public int InstrumentId { get; set; }
		public string Name { get; set; }

		public InstrumentResponseModel(Instrument instrument)
		{
			InstrumentId = instrument.InstrumentId;
			Name = instrument.Name;
		}
	}
}