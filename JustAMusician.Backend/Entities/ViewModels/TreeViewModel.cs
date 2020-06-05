using System.Collections.Generic;

namespace JustAMusician.Backend.Entities.ViewModels
{
	public class TreeViewModel
	{
		public string Value { get; set; }

		public string Label { get; set; }

		public List<TreeViewModel> Children { get; set; }

		public TreeViewModel() {}
		public TreeViewModel(Genre genre)
		{
			Value = $"{genre.GenreId}";
			Label = genre.Title;
		}
	}
}