using System;

using Autofac;
using Autofac.Extras.DynamicProxy2;

namespace AutofacSamples.DynamicProxy
{
    class DynamicProxyExample
    {
        public static void Execute()
        {
            ContainerBuilder containerBuilder = new ContainerBuilder();

            containerBuilder.Register(c => Console.Out);
            containerBuilder.RegisterType<ConsoleLoggerInterceptor>();
            containerBuilder.RegisterType<Wrapped>()
                            .EnableClassInterceptors()
                            .InterceptedBy(typeof(ConsoleLoggerInterceptor));

            using (IContainer container = containerBuilder.Build())
            {
                Wrapped wrapped = container.Resolve<Wrapped>();
                wrapped.SaySomething();
            }
        }
    }
}
