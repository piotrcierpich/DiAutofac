namespace AutofacSamples.SimpleDi
{
    class DiNoContainerExample
    {
        public static void Execute()
        {
          IMovieFinder xmlMovieFinder = new XmlMovieFinder("Movies.xml");
          Movie[] spielbergMovies = new MovieLister(xmlMovieFinder).GetMoviesDirectedBy("Steven Spielberg");
          spielbergMovies.PrintToConsole();
        }
    }
}
