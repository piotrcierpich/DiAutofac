using System;
using Autofac;
using System.Diagnostics;

namespace AutofacSamples.Scoping
{
  class ScopingExample
  {
    public static void Execute()
    {
      IContainer container = ConfigurePerDependency();
      PerDependencyCheck(container);
      container = ConfigureSingleton();
      SingletonCheck(container);
      container = ConfigureLifetimeScope();
      LifetimeScopeCheck(container);

      Console.WriteLine("Scoping example complete");
    }

    static IContainer ConfigurePerDependency()
    {
      ContainerBuilder containerBuilder = new ContainerBuilder();
      // default
      containerBuilder.RegisterType<Movie>().InstancePerDependency();
      return containerBuilder.Build();
    }

    static IContainer ConfigureSingleton()
    {
      ContainerBuilder containerBuilder = new ContainerBuilder();
      containerBuilder.RegisterType<Movie>().SingleInstance();
      return containerBuilder.Build();
    }

    static IContainer ConfigureLifetimeScope()
    {
      ContainerBuilder containerBuilder = new ContainerBuilder();
      containerBuilder.RegisterType<Movie>().InstancePerLifetimeScope();
      return containerBuilder.Build();
    }

    static void PerDependencyCheck(IContainer container)
    {
      Debug.Assert(container.Resolve<Movie>().GetHashCode() != container.Resolve<Movie>().GetHashCode());
    }

    static void SingletonCheck(IContainer container)
    {
      Debug.Assert(container.Resolve<Movie>().GetHashCode() == container.Resolve<Movie>().GetHashCode());
    }

    static void LifetimeScopeCheck(IContainer container)
    {
      int previousScopeComponentHashcode;
      using (ILifetimeScope scopeContext = container.BeginLifetimeScope())
      {
        Debug.Assert(scopeContext.Resolve<Movie>().GetHashCode() == scopeContext.Resolve<Movie>().GetHashCode());
        previousScopeComponentHashcode = scopeContext.Resolve<Movie>().GetHashCode();
      }
      using (ILifetimeScope scopeContext = container.BeginLifetimeScope())
      {
        Debug.Assert(scopeContext.Resolve<Movie>().GetHashCode() != previousScopeComponentHashcode);
      }
    }
  }
}
