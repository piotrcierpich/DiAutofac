
using AutofacSamples.ComplicatingThings;

namespace AutofacSamples.NoContainerDi
{
    class NoContainerProblemExample
    {
        public static void Execute()
        {
            IMovieRatingFactory movieRatingFactory = new GoodMovieRatingFactory();

            using (FileLogger fileLogger = new FileLogger())
            {
                using (FileLogger fileLoggerForMovieLister = new FileLogger())
                {
                    IMovieFinder movieWithRatingsFinder = new XmlMovieWithRatingsFinder("Movies.xml", movieRatingFactory, fileLogger);
                    IMovieLister movieLister = new MovieListerWithLogging(movieWithRatingsFinder, fileLoggerForMovieLister);
                    Movie[] moviesWithRatings = movieLister.GetMoviesDirectedBy("Steven Spielberg");
                    moviesWithRatings.PrintToConsole();
                }
            }
        }
    }
}
