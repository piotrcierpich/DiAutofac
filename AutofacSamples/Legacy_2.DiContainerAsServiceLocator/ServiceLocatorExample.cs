using System;

namespace AutofacSamples.DiContainerAsServiceLocator
{
    class ServiceLocatorExample
    {
        public static void Execute()
        {
            Movie[] spielbergMovies = new MovieLister().GetMoviesDirectedBy("Steven Spielberg");
            foreach (Movie m in spielbergMovies)
                Console.WriteLine(m);
        }
    }
}
