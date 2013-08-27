using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutofacSamples.Modules
{
    class AlternativeMovieFinder : IMovieFinder
    {
        #region IMovieFinder Members

        public Movie[] FindMovies()
        {
            return new Movie[]
            {
                new Movie(){ Director = "Alfonso Cuarón", Title = "Harry Potter and the Prisoner of Azkaban" },
                new Movie(){ Director = "Steven Spielberg", Title = "Saving Private Ryan" },
                new Movie(){ Director = "Steven Spielberg", Title = "The Lost World: Jurassic Park" },
                new Movie(){ Director = "Steven Spielberg", Title = "E.T." }                
            };
        }

        #endregion
    }
}
