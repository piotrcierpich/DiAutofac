using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutofacSamples.DependencyInjection1
{
    class MovieLister
    {
        private IMovieFinder finder;

        public MovieLister(IMovieFinder movieFinderImpl)
        {
            finder = movieFinderImpl;
        }

        public Movie[] GetMoviesDirectedBy(string director)
        {
            Movie[] allMovies = finder.FindMovies();
            return allMovies.Where(m => m.Director == director).ToArray();
        }
    }
}
