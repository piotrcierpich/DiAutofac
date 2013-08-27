using AutofacSamples.ComplicatingThings;

namespace AutofacSamples.Modules
{
  class InMemoryMovieFinder : IMovieFinder
  {
    private readonly Movie[] _movies;

    public InMemoryMovieFinder()
    {
      _movies = new Movie[]
        {
          new MovieWithRating{Title = "The Dark Knight", Director = "Christopher Nolan"},
          new MovieWithRating{Title = "Fight Club", Director = "David Fincher"},
          new MovieWithRating{Title = "Munich", Director = "Steven Spielberg", Rating = 7.5f},
          new MovieWithRating{Title = "Transformers", Director = "Steven Spielberg", Rating = 7.0f}
        };
    }

    public Movie[] FindMovies()
    {
      return _movies;
    }
  }
}
