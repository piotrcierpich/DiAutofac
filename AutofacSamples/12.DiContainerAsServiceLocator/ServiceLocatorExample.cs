using System;

using Autofac;

namespace AutofacSamples.DiContainerAsServiceLocator
{
    class ServiceLocatorExample
    {
        public static void Execute()
        {
            ContainerBuilder containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterType<Speaker>();
            containerBuilder.RegisterType<Microphone>();

            IContainer container = containerBuilder.Build();
            Speaker speaker = container.Resolve<Speaker>();
            speaker.SpeakOutLoud("one two one two...");
        }
    }

    internal class Microphone
    {
        private readonly IContainer serviceLocator;
        private Speaker speaker;

        public Microphone(IContainer serviceLocator)
        {
            this.serviceLocator = serviceLocator;
        }

        public void Speaking(string speech)
        {
            Speaker.SpeakOutLoud(speech);
        }

        private Speaker Speaker
        {
            get { return speaker ?? (speaker = serviceLocator.Resolve<Speaker>()); }
        }
    }

    internal class Speaker
    {
        public void SpeakOutLoud(string speech)
        {
            Console.WriteLine(speech);
        }
    }
}
