using System;
using System.Collections.Generic;
using System.Text;

namespace VCSManager.Movie.Model.SearchResults
{
	using System.Dynamic;

	public class MovieSearchResult
	{
		public int Page { get; set; }

		public int TotalPages { get; set; }

		public int TotalResults { get; set; }

		public List<MovieSearch> Results { get; set; }
	}

	public class MovieSearch
	{
		public long Id { get; set; }

		public string Title { get; set; }

		public string OriginalTitle { get; set; }
	}
}
