using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutofacSamples.XmlConfiguration
{
    class MovieLister
    {
        public Movie[] GetMoviesDirectedBy(string director)
        {
            Movie[] allMovies = finder.FindMovies();
            return allMovies.Where(m => m.Director == director).ToArray();
        }

        private IMovieFinder finder;
        public IMovieFinder MovieFinder
        {
            get { return finder; }
            set { finder = value; }
        }
    }
}
