using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;

namespace AutofacSamples.ComponentsTesting
{
    class MocksExample
    {
        private static IComponentContext context;
        static MocksExample()
        {
            Configure();
        }

        static void Configure()
        {
            ContainerBuilder containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterType<MovieLister>();
            containerBuilder.RegisterInstance(MovieFinderMock.Instance);
            context = containerBuilder.Build();
        }

        public static void Execute()
        {
            MovieLister movieLister = context.Resolve<MovieLister>();
            Movie[] spielbergMovies = movieLister.GetMoviesDirectedBy("Steven Spielberg");
            foreach (Movie m in spielbergMovies)
                Console.WriteLine(m);
        }
    }
}
