using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;

namespace AutofacSamples.Modules
{
    class MovieFinderCustomModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MovieLister>();
            if (IsHddAvailable)
                builder.Register(c => new XmlMovieFinder("Movies.xml")).As<IMovieFinder>();
            else
                builder.RegisterType<AlternativeMovieFinder>().As<IMovieFinder>();
        }

        public bool IsHddAvailable { get; set; }
    }
}
