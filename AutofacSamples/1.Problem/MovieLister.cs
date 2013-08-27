using System.Linq;

namespace AutofacSamples.Problem
{
    class MovieLister
    {
        private readonly IMovieFinder finder;

        public MovieLister()
        {
            finder = new XmlMovieFinder("Movies.xml");
        }

        public Movie[] GetMoviesDirectedBy(string director)
        {
            Movie[] allMovies = finder.FindMovies();
            return allMovies.Where(m => m.Director == director).ToArray();
        }
    }
}
