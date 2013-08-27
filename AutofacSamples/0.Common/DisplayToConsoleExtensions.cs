using System;

namespace AutofacSamples
{
    public static class DisplayToConsoleExtensions
    {
        public static void PrintToConsole(this Movie[] movies)
        {
            if (movies == null)
                return;

            foreach (var movie in movies)
            {
                Console.WriteLine(movie.ToString());
            }
        }
    }
}
