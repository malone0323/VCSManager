using System;
using System.Collections.Generic;
using System.Text;

namespace VCSManager.Movie.Model.SearchResults
{
	public class MovieCredits
	{
		public int Id { get; set; }

		public List<ActorCredit> Cast { get; set; }
	}

	public class ActorCredit : Actor
	{
		public string Character { get; set; }

		public string Department { get; set; }

		public string Job { get; set; }
	}
}
