using System;
using Autofac;

namespace AutofacSamples.PropertyInjection
{
  class PropertyInjectionExample
  {
    public static void Execute()
    {
      ContainerBuilder containerBuilder = new ContainerBuilder();
      containerBuilder.RegisterType<Dependent>().PropertiesAutowired();
      containerBuilder.RegisterType<Dependee>();

      IContainer container = containerBuilder.Build();

      Dependent dependent = container.Resolve<Dependent>();
      Console.WriteLine(dependent.ToString());
    }
  }
}
