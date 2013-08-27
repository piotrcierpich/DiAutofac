using System.IO;
using Autofac;
using AutofacSamples.ComplicatingThings;
using AutofacSamples.ComplicatingThings.Ratings;

namespace AutofacSamples.DelegateFactories
{
  class DelegateFactoriesExample
  {
    public static void Execute()
    {
      ContainerBuilder containerBuilder = new ContainerBuilder();

      containerBuilder.RegisterType<StreamWriter>();
      containerBuilder.RegisterType<FileLogger>().As<ILogger>();
      
      //containerBuilder.RegisterType<GoodMovieRatingFactory>().AsImplementedInterfaces();
      containerBuilder.RegisterType<GoodMovieRating>().As<IMovieRating>();

      containerBuilder.RegisterType<XmlMovieWithRatingsFinder>()
                      .AsImplementedInterfaces()
                      .WithParameter(new TypedParameter(typeof(string), "Movies.xml"));
      containerBuilder.RegisterType<MovieListerWithLogging>();

      using (IContainer container = containerBuilder.Build())
      {
        IMovieLister movieLister = container.Resolve<MovieListerWithLogging>();
        Movie[] moviesWithRatings = movieLister.GetMoviesDirectedBy("Steven Spielberg");
        moviesWithRatings.PrintToConsole();
      }
    }
  }
}
