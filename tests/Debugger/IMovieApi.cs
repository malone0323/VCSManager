namespace Debugger
{
	using System.Threading.Tasks;

	using Refit;

	using VCSManager.Movie.Model;
	using VCSManager.Movie.Model.SearchResults;

	public interface IMovieApi
	{
		[Get("/person/{actorId}?api_key={api}")]
		Task<Actor> GetActorDetails(long actorId, string api);

		[Get("/search/movie?api_key={api}&query={query}")]
		Task<MovieSearchResult> SearchMovies(string query, string api, int page = 1);

		[Get("/movie/{movieId}?api_key={api}")]
		Task<Movie> GetMovieDetails(long movieId, string api);

		[Get("/movie/{movieId}/credits?api_key={api}")]
		Task<MovieCredits> GetMovieCredits(long movieId, string api);
	}
}
