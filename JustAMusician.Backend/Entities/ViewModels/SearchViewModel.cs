using System;
using System.Collections.Generic;

namespace JustAMusician.Backend.Entities.ResponseModels
{
	public class SearchViewModel
	{
		public List<string> Genres { get; set; }
		public List<string> Instruments { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public bool SortAsc { get; set; }
	}
}