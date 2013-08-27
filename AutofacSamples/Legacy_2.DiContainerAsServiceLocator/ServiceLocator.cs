using Autofac;

namespace AutofacSamples.DiContainerAsServiceLocator
{
    class ServiceLocator
    {
        private ServiceLocator() { }
        static ServiceLocator()
        {
            Configure();
        }

        static void Configure()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<XmlMovieFinder>()
                .WithParameter(new NamedParameter("filePath", "Movies.xml"))
                .As<IMovieFinder>();
            container = builder.Build();
        }

        private static IContainer container;
        public static IContainer Instance
        {
            get { return container; }
        }
    }
}
