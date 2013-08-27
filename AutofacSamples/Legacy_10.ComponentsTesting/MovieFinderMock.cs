using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;

namespace AutofacSamples.ComponentsTesting
{
    class MovieFinderMock
    {
        public static IMovieFinder Instance
        {
            get
            {
                Mock<IMovieFinder> movieFinderMock = new Mock<IMovieFinder>();
                movieFinderMock.Setup(e => e.FindMovies())
                               .Returns(
                                   new Movie[]
                               {
                                    new Movie(){ Director = "Alfonso Cuarón", Title = "Harry Potter and the Prisoner of Azkaban" },
                                    new Movie(){ Director = "Steven Spielberg", Title = "Saving Private Ryan" }
                               }
                               );
                return movieFinderMock.Object;
            }
        }
    }
}
