using AutofacSamples.ComplicatingThings.Ratings;

namespace AutofacSamples.ComplicatingThings
{
    internal class GoodMovieRatingFactory : IMovieRatingFactory
    {
        public IMovieRating Create(string title)
        {
            //return new RestServiceMovieRating(title);
          return new GoodMovieRating(title);
        }
    }
}