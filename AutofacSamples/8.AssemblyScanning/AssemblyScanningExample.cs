using System.Reflection;
using Autofac;
using AutofacSamples.ComplicatingThings;

namespace AutofacSamples.AssemblyScanning
{
  class AssemblyScanningExample
  {
    public static void Execute()
    {
      Assembly currentAssembly = Assembly.GetExecutingAssembly();

      ContainerBuilder containerBuilder = new ContainerBuilder();

      //containerBuilder.RegisterType<FileLogger>().As<ILogger>();
      containerBuilder.RegisterAssemblyTypes(currentAssembly)
                      .Where(t => t.Namespace == "AutofacSamples.ComplicatingThings")
                      .AsImplementedInterfaces();

      containerBuilder.RegisterType<GoodMovieRatingFactory>().AsImplementedInterfaces();
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
