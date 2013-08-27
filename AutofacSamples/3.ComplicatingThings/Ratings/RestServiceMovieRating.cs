using System.Linq;
using System.Net.Http;

using Newtonsoft.Json;

namespace AutofacSamples.ComplicatingThings
{
    internal class RestServiceMovieRating : IMovieRating
    {
        private const string EndpointFormat = "http://mymovieapi.com/?title={0}&type=json";
        private readonly string endpoint;

        public RestServiceMovieRating(string title)
        {
            endpoint = GetEndpointForTitle(title);
        }

        private string GetEndpointForTitle(string title)
        {
            string formattedTitle = GetFormattedTitle(title);
            return string.Format(EndpointFormat, formattedTitle);
        }

        private string GetFormattedTitle(string title)
        {
            if (string.IsNullOrEmpty(title))
                return string.Empty;

            return title.Replace(' ', '+');
        }

        public float GetRating()
        {
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetAsync(endpoint).Result;
                string responseAsString = response.Content.ReadAsStringAsync().Result;
                MovieRating[] movieRating = JsonConvert.DeserializeObject<MovieRating[]>(responseAsString);
                return movieRating.Any() ? movieRating.First().Rating : 9.0f;
            }
        }

// ReSharper disable ClassNeverInstantiated.Local
        private class MovieRating
// ReSharper restore ClassNeverInstantiated.Local
        {
            [JsonProperty("rating")]
            public float Rating { get; set; }
        }
    }
}