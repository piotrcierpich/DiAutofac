using Autofac;
using AutofacSamples.ComplicatingThings;

namespace AutofacSamples.Modules
{
  class MoviesModule : Module
  {
    private readonly bool hasHddAccess;

    public MoviesModule(bool hasHddAccess)
    {
      this.hasHddAccess = hasHddAccess;
    }

    protected override void Load(ContainerBuilder containerBuilder)
    {
      if (hasHddAccess)
      {
        containerBuilder.RegisterType<GoodMovieRatingFactory>().As<IMovieRatingFactory>();
        containerBuilder.RegisterType<XmlMovieWithRatingsFinder>()
                        .AsImplementedInterfaces()
                        .WithParameter(new TypedParameter(typeof(string), "Movies.xml"));
      }
      else
      {
        containerBuilder.RegisterType<InMemoryMovieFinder>().As<IMovieFinder>();
      }

      containerBuilder.RegisterType<FileLogger>().As<ILogger>();
      containerBuilder.RegisterType<MovieListerWithLogging>();
    }
  }
}
