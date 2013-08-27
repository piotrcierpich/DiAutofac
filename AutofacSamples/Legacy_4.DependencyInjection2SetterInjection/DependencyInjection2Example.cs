using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;

namespace AutofacSamples.DependencyInjection2SetterInjection
{
    class DependencyInjection2Example
    {
        private static IContainer container;

        static DependencyInjection2Example()
        {
            Configure();
        }

        static void Configure()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.Register(c => new XmlMovieFinder("Movies.xml")).As<IMovieFinder>();
            //builder.Register(c => new MovieLister() { MovieFinder = c.Resolve<IMovieFinder>() });
            //builder.RegisterType<MovieLister>().OnActivated(c => c.Instance.MovieFinder = c.Context.Resolve<IMovieFinder>());
            //builder.RegisterType<MovieLister>().OnActivated(c => c.Context.InjectProperties(c.Instance));
            builder.RegisterType<MovieLister>().PropertiesAutowired();            
            container = builder.Build();
        }

        public static void Execute()
        {
            MovieLister movieLister = container.Resolve<MovieLister>();
            Movie[] spielbergMovies = movieLister.GetMoviesDirectedBy("Steven Spielberg");
            foreach (Movie m in spielbergMovies)
                Console.WriteLine(m);
        }
    }
}
