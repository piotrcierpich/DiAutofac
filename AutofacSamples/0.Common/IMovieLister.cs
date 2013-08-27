namespace AutofacSamples
{
    internal interface IMovieLister
    {
        Movie[] GetMoviesDirectedBy(string director);
    }
}