using System;
using System.Collections.Generic;
using System.Text;

namespace Debugger
{
	using System.Threading.Tasks;

	using Newtonsoft.Json;

	using Refit;

	using VCSManager.Movie.Model;
	using VCSManager.Movie.Model.SearchResults;

	public class MovieApi
	{
		public MovieApi(string apiKey, int version = 3)
		{
			ApiKey = apiKey;
			Service = RestService.For<IMovieApi>($"https://api.themoviedb.org/{version}/");
		}

		private string ApiKey { get; }

		private IMovieApi Service { get; }

		public Task<Actor> GetActorDetailsAsync(long actorId)
			=> Service.GetActorDetails(actorId, ApiKey);

		public Task<MovieSearchResult> SearchMoviesAsync(string query, int page = 1)
			=> Service.SearchMovies(query, ApiKey, page);

		public Task<Movie> GetMovieDetailsAsync(long movieId)
			=> Service.GetMovieDetails(movieId, ApiKey);

		public Task<MovieCredits> GetMovieCreditsAsync(long movieId)
			=> Service.GetMovieCredits(movieId, ApiKey);
	}
}
