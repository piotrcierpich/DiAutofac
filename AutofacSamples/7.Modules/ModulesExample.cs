using Autofac;
using AutofacSamples.ComplicatingThings;

namespace AutofacSamples.Modules
{
  class ModulesExample
  {
    public static void Execute()
    {
      ContainerBuilder containerBuilder = new ContainerBuilder();
      containerBuilder.RegisterModule(new MoviesModule(hasHddAccess: false));
      using (IContainer container = containerBuilder.Build())
      {
        IMovieLister movieLister = container.Resolve<MovieListerWithLogging>();
        Movie[] moviesWithRatings = movieLister.GetMoviesDirectedBy("Steven Spielberg");
        moviesWithRatings.PrintToConsole();
      }
    }
  }
}
