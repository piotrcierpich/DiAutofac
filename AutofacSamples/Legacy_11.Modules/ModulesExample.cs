using System;
using Autofac;
using Autofac.Configuration;

namespace AutofacSamples.Modules
{
    class ModulesExample2
    {
        private static IComponentContext context;
        static ModulesExample2()
        {
            Configure();
        }

        static void Configure()
        {
            ContainerBuilder containerBuilder = new ContainerBuilder();
            //containerBuilder.RegisterModule(new MovieFinderCustomModule() { IsHddAvailable = false });
            containerBuilder.RegisterModule(new ConfigurationSettingsReader("customModuleConfigurationSection"));            
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
