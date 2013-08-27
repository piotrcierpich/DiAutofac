using System.IO;

using Castle.DynamicProxy;

namespace AutofacSamples.DynamicProxy
{
    class ConsoleLoggerInterceptor : IInterceptor
    {
        private readonly TextWriter output;

        public ConsoleLoggerInterceptor(TextWriter output)
        {
            this.output = output;
        }

        public void Intercept(IInvocation invocation)
        {
            output.WriteLine("Calling method: " + invocation.Method.Name);

            invocation.Proceed();

            output.WriteLine("Calling complete method: " + invocation.Method.Name);
        }
    }
}
