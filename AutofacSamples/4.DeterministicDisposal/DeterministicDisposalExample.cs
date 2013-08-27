using Autofac;
using AutofacSamples.ComplicatingThings;

namespace AutofacSamples.DeterministicDisposal
{
  class DeterministicDisposalExample
  {
    public static void Execute()
    {
      ContainerBuilder containerBuilder = new ContainerBuilder();
      containerBuilder.RegisterType<FileLogger>().As<ILogger>();
      containerBuilder.RegisterType<GoodMovieRatingFactory>().AsImplementedInterfaces();
      containerBuilder.RegisterType<XmlMovieWithRatingsFinder>()
                      .AsImplementedInterfaces()
                      .WithParameter(new TypedParameter(typeof (string), "Movies.xml"));
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
