namespace JustAMusician.Backend.Entities.ResponseModels
{
	public class BandResponseModelShort
	{
		public int BandId { get; set; }
		public int LeaderId { get; set; }
		public string LeaderNickname { get; set; }
		public string Name { get; set; }

		public BandResponseModelShort(Band band)
		{
			BandId = band.BandId;
			LeaderId = band.LeaderId;
			LeaderNickname = band.Leader.Nickname;
			Name = band.Name;
		}
	}
}