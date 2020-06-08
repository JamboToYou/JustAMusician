using System.Collections.Generic;

namespace JustAMusician.Backend.Entities.ResponseModels
{
	public class TreeViewResponseModel
	{
		public string Value { get; set; }

		public string Label { get; set; }

		public List<TreeViewResponseModel> Children { get; set; }

		public TreeViewResponseModel() {}
		public TreeViewResponseModel(Genre genre)
		{
			Value = $"{genre.GenreId}";
			Label = genre.Title;
		}
	}
}