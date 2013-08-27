using System.Linq;
using Autofac;

namespace AutofacSamples.DiContainerAsServiceLocator
{
    class MovieLister
    {
        private IMovieFinder movieFinder;        

        public MovieLister()
        {
            movieFinder = ServiceLocator.Instance.Resolve<IMovieFinder>();
        }

        public Movie[] GetMoviesDirectedBy(string director)
        {
            Movie[] allMovies = movieFinder.FindMovies();
            return allMovies.Where(m => m.Director == director).ToArray();
        }
    }
}
