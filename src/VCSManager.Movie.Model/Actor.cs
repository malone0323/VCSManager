namespace VCSManager.Movie.Model
{
	using System;

	using Newtonsoft.Json;

	public class Actor
	{
		public long Id { get; set; }

		public string Name { get; set; }

		public Gender Gender { get; set; }

		[JsonProperty("profile_path")]
		public Uri Thumbnail { get; set; }
	}

}
