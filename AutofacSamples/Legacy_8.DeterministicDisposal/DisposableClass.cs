using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace AutofacSamples.DeterministicDisposal
{
    class DisposableClass : IDisposable
    {
        private StreamWriter disposableResource;
        public DisposableClass()
        {
            disposableResource = File.CreateText("sampleResource.txt");
        }

        #region IDisposable Members

        public void Dispose()
        {
            disposableResource.Close();
            Console.WriteLine("Dispose is done!");
        }

        #endregion
    }
}
