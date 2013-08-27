namespace AutofacSamples
{
    public class Movie
    {
        public override string ToString()
        {
            return string.Format("Director: {0}, Title: {1}", Director, Title);
        }

        public string Director { get; set; }
        public string Title { get; set; }
    }
}
