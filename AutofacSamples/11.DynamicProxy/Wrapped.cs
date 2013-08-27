using System;

namespace AutofacSamples.DynamicProxy
{
    public class Wrapped
    {
        public virtual void SaySomething()
        {
            Console.WriteLine("This is SaySomething method being executed");
        }
    }
}
