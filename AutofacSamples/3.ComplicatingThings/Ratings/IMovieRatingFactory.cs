namespace AutofacSamples.ComplicatingThings
{
    internal interface IMovieRatingFactory
    {
        IMovieRating Create(string title);
    }
}