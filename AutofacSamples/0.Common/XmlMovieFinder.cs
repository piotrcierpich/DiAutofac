using System.Linq;
using System.Xml.Linq;

namespace AutofacSamples
{
    class XmlMovieFinder : IMovieFinder
    {
        private readonly string pathToSourceFile;

        public XmlMovieFinder(string filePath)
        {
            pathToSourceFile = filePath;
        }

        public Movie[] FindMovies()
        {
            XDocument moviesDoc = XDocument.Load(pathToSourceFile);
            return moviesDoc.Root
                            .Elements()
                            .Select(c => new Movie
                                        { 
                                            Director = c.Element("Director").Value,
                                            Title = c.Element("Title").Value 
                                        })
                            .ToArray();
        }
    }
}
