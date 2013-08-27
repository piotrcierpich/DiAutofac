namespace AutofacSamples.ComplicatingThings.Ratings
{
  class GoodMovieRating : IMovieRating
  {
    private readonly string title;

    public GoodMovieRating(string title)
    {
      this.title = title;
    }

    public float GetRating()
    {
      return title.Contains("The") ? 9.0f : 8.5f;
    }
  }
}
