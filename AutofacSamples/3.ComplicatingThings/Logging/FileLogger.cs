using System;
using System.IO;

namespace AutofacSamples.ComplicatingThings
{
  class FileLogger : ILogger, IDisposable
  {
    private readonly StreamWriter sw;

    public FileLogger()
    {
      string logFileName = Path.GetTempFileName();
      sw = new StreamWriter(logFileName, append: true);
    }

    public void Log(string message)
    {
      sw.WriteLine(message);
    }

    public void Dispose()
    {
      sw.Dispose();
    }
  }
}
