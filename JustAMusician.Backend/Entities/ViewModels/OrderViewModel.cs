using System.Collections.Generic;

namespace JustAMusician.Backend.Entities.ViewModels
{
	public class OrderViewModel
	{
		public int OrderId { get; set; }
		public string Title { get; set; }
		public string Body { get; set; }
		public bool ForBand { get; set; }
		public List<string> Genres { get; set; }
		public List<string> Instruments { get; set; }
	}
}