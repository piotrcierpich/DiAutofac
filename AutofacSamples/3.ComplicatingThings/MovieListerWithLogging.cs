using System.Linq;

namespace AutofacSamples.ComplicatingThings
{
    class MovieListerWithLogging : IMovieLister
    {
        private readonly IMovieFinder movieFinder;
        private readonly ILogger logger;

        public MovieListerWithLogging(IMovieFinder movieFinder, ILogger logger)
        {
            this.movieFinder = movieFinder;
            this.logger = logger;
        }

        public Movie[] GetMoviesDirectedBy(string director)
        {
            logger.Log("GetMoviesDirectedBy:" + director);
            Movie[] allMovies = movieFinder.FindMovies();
            return allMovies.Where(m => m.Director == director).ToArray();
        }
    }
}
