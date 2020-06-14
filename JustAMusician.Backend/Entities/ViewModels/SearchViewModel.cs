using System;
using System.Collections.Generic;

namespace JustAMusician.Backend.Entities.ViewModels
{
	public class SearchViewModel
	{
		public List<string> Genres { get; set; }
		public List<string> Instruments { get; set; }
		public string StartDate { get; set; }
		public string EndDate { get; set; }
	}
}