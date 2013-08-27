using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Autofac;

namespace AutofacSamples.ServiceLocatorSelfRegistered
{
    class MovieLister
    {
        private IComponentContext myContext;

        public MovieLister(IComponentContext context)
        {
            myContext = context;
        }

        public Movie[] GetMoviesDirectedBy(string director)
        {
            Movie[] allMovies = myContext.Resolve<IMovieFinder>().FindMovies();
            return allMovies.Where(m => m.Director == director).ToArray();
        }
    }
}
