using System.Collections.Generic;

namespace JustAMusician.Backend.Entities.ViewModels
{
	public class UserEditViewModel
	{
		public string About { get; set; }
		public List<string> Links { get; set; }
		public List<string> Instruments { get; set; }
	}
}