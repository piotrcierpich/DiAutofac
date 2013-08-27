using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AutofacSamples.Problem
{
    class MovieLister
    {
        private IMovieFinder finder;

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
