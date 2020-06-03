namespace JustAMusician.Backend.Entities
{
	public class OrderShort
	{

		public OrderShort(string title, string body)
		{
			Title = title;
			Body = body;
		}

		public string Title { get; set; }
		public string Body { get; set; }
	}
}
