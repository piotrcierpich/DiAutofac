using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using Autofac.Configuration;

namespace AutofacSamples.XmlConfiguration
{
    class XmlConfigurationExample2
    {
        private static IContainer container;

        static XmlConfigurationExample2()
        {
            ContainerBuilder containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule(new ConfigurationSettingsReader("autofacConfigurationSection"));
            container = containerBuilder.Build();
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
