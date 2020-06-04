namespace JustAMusician.Backend.Entities.Relations
{
	public class OrderTag
	{
		public int OrderId { get; set; }
		public Order Order { get; set; }

		public int TagId { get; set; }
		public Tag Tag { get; set; }
	}
}