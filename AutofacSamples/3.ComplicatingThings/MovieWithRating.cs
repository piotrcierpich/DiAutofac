namespace AutofacSamples.ComplicatingThings
{
    public class MovieWithRating : Movie
    {
        public override string ToString()
        {
            return string.Format("Director: {0}, Title: {1}, Rating: {2}", Director, Title, Rating);
        }

        public float Rating { get; set; }
    }
}