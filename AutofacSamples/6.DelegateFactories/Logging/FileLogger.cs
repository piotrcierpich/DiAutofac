using System;
using System.IO;
using AutofacSamples.ComplicatingThings;

namespace AutofacSamples.DelegateFactories
{
  class FileLogger : ILogger
  {
    private readonly StreamWriter sw;

    public FileLogger(Func<string, StreamWriter> streamWriterFactory)
      : this("defaultLog.txt", streamWriterFactory)
    { }

    public FileLogger(string fileName, Func<string, StreamWriter> streamWriterFactory)
    {
      sw = streamWriterFactory(fileName);
    }

    public void Log(string message)
    {
      sw.WriteLine(message);
    }
  }
}
