namespace JustAMusician.Backend.Entities.ResponseModels
{
	public class LinkResponseModel
	{
		public int LinkId { get; set; }
		public string Url { get; set; }

		public LinkResponseModel(Link link)
		{
			LinkId = link.LinkId;
			Url = link.Url;
		}
	}
}