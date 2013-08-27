using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;

namespace AutofacSamples.DependencyInjection3
{
    class DependencyInjection3Example
    {
        private static IContainer container;

        static DependencyInjection3Example()
        {
            Configure();
        }

        static void Configure()
        {
            ContainerBuilder builder = new ContainerBuilder();
            //builder.Register(c => new XmlMovieFinder("Movies.xml")).As<IMovieFinder>();
            builder.RegisterType<AlternativeMovieFinder>().As<IMovieFinder>();
            builder.RegisterType<MovieLister>();
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
