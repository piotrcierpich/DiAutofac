using System.Linq;
using System.Xml.Linq;

namespace AutofacSamples.ComplicatingThings
{
    class XmlMovieWithRatingsFinder : IMovieFinder
    {
        private readonly string pathToSourceFile;
        private readonly IMovieRatingFactory movieRatingFactory;
        private readonly ILogger logger;

        public XmlMovieWithRatingsFinder(string filePath, IMovieRatingFactory movieRatingFactory, ILogger logger)
        {
            pathToSourceFile = filePath;
            this.movieRatingFactory = movieRatingFactory;
            this.logger = logger;
        }

        public Movie[] FindMovies()
        {
            logger.Log("Finding movies");

            XDocument moviesDoc = XDocument.Load(pathToSourceFile);
            MovieWithRating[] movieWithRating = moviesDoc.Root
                                                        .Elements()
                                                        .Select(c =>
                                                        {
                                                            string title = c.Element("Title").Value;
                                                            return new MovieWithRating
                                                            {
                                                                Director = c.Element("Director").Value,
                                                                Title = title,
                                                                Rating = GetRating(title)
                                                            };
                                                        })
                                                        .ToArray();

            logger.Log("Movie finding complete");
            return movieWithRating;
        }

        private float GetRating(string title)
        {
            IMovieRating movieRating = movieRatingFactory.Create(title);
            return movieRating.GetRating();
        }
    }
}
