using System.Linq;

namespace AutofacSamples.SimpleDi
{
    class MovieLister : IMovieLister
    {
        private readonly IMovieFinder movieFinder;

        public MovieLister(IMovieFinder movieFinder)
        {
            this.movieFinder = movieFinder;
        }

        public Movie[] GetMoviesDirectedBy(string director)
        {
            Movie[] allMovies = movieFinder.FindMovies();
            return allMovies.Where(m => m.Director == director).ToArray();
        }
    }
}
