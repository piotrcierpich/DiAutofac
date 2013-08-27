using Autofac;

namespace AutofacSamples.SimpleDi
{
    class DiWIthContainerExample
    {
        // container works as a builder which with configuration
        public static void Execute()
        {
            ContainerBuilder containerBuilder = new ContainerBuilder();
            containerBuilder.Register(c => new XmlMovieFinder("Movies.xml")).As<IMovieFinder>();
            containerBuilder.RegisterType<MovieLister>();

            IContainer container = containerBuilder.Build();
            MovieLister movieLister = container.Resolve<MovieLister>();
            Movie[] spielbergMovies = movieLister.GetMoviesDirectedBy("Steven Spielberg");
            spielbergMovies.PrintToConsole();
        }
    }
}
