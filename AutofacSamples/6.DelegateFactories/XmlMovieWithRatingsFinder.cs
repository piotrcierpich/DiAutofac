using System;
using System.Linq;
using System.Xml.Linq;
using AutofacSamples.ComplicatingThings;

namespace AutofacSamples.DelegateFactories
{
  class XmlMovieWithRatingsFinder : IMovieFinder
  {
    private readonly string _pathToSourceFile;
    private readonly Func<string, IMovieRating> _movieRatingFactory;
    private readonly ILogger _logger;

    public XmlMovieWithRatingsFinder(string filePath, Func<string, IMovieRating> movieRatingFactory, Func<string, ILogger> loggerFactory)
    {
      _pathToSourceFile = filePath;
      _movieRatingFactory = movieRatingFactory;
      _logger = loggerFactory("XmlMovieRatingFinderLog.txt");
    }

    public Movie[] FindMovies()
    {
      _logger.Log("Finding movies");

      XDocument moviesDoc = XDocument.Load(_pathToSourceFile);
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

      _logger.Log("Movie finding complete");
      return movieWithRating;
    }

    private float GetRating(string title)
    {
      IMovieRating movieRating = _movieRatingFactory(title);
      return movieRating.GetRating();
    }
  }
}
