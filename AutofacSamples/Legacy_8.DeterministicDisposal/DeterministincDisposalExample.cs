using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;

namespace AutofacSamples.DeterministicDisposal
{
class DeterministincDisposalExample
{
    private static IContainer container;
    static DeterministincDisposalExample()
    {
        ContainerBuilder containerBuilder = new ContainerBuilder();
        containerBuilder.RegisterType<DisposableClass>();
        container = containerBuilder.Build();
    }

    public static void Execute()
    {
        using (ILifetimeScope lifetimeContext = container.BeginLifetimeScope())
        {
            lifetimeContext.Resolve<DisposableClass>();
        }
    }
}
}
