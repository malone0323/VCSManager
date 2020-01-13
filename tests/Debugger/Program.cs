namespace Debugger
{
	using System;
	using System.Linq;
	using System.Net;
	using System.Threading.Tasks;

	using Refit;

	public static class Program
	{
		public static async Task Main(string[] args)
		{
			var api = new MovieApi(Environment.GetEnvironmentVariable("MovieDbApi"));

			try
			{
				// var actor = await api.GetActorDetailsAsync(17018);
				var movies = await api.SearchMoviesAsync("Lord of the rings");
				var movie = await api.GetMovieDetailsAsync(movies.Results.First().Id);
				var credits = await api.GetMovieCreditsAsync(movie.Id);
				var weinstein = credits.Cast.SingleOrDefault(x => x.Name == "Bob Weinstein");
				var roles = credits.Cast.Select(x => x.Character).Distinct().ToList();
				var jobs = credits.Cast.Select(x => x.Job).Distinct().ToList();
				var departments = credits.Cast.Select(x => x.Department).Distinct().ToList();
				var actors = (await api.GetMovieCreditsAsync(movie.Id)).Cast;
			}
			catch (ApiException e) when (e.StatusCode == HttpStatusCode.NotFound)
			{
				Console.WriteLine("Resource with that Id was not found!");
			}
			catch (ApiException e) when (e.StatusCode == HttpStatusCode.Unauthorized)
			{
				Console.WriteLine("Invalid Api Token!");
			}
			catch (ApiException e)
			{
				Console.WriteLine($"Error! \n\t{e.Message} \n\t{e.ReasonPhrase} \n\t{e.RequestMessage}");
			}
		}
	}
}
