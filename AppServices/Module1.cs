using System;
using AppServices;
using Autofac;

namespace WebApplication3
{
    public delegate void Registration<T>(ContainerBuilder builder);

    public static class Registration
    {
        public static Registration<T> Create<T, TImplementation>()
            => _ => _.RegisterType<TImplementation>().As<T>();

        public static Registration<T> Create<T>(Func<IComponentContext, T> implementationFactory)
            => _ => _.Register(implementationFactory).As<T>();
    }

    public class Module1Settings
    {
        public Registration<IProvider1> Provider1 = Registration.Create<IProvider1, Provider1>();        
    }

    public class Module1 : Module
    {
        private readonly Module1Settings settings;

        public Module1(Module1Settings settings)
        {
            this.settings = settings;
        }

        protected override void Load(ContainerBuilder builder)
        {
            settings.Provider1(builder);
        }
    }
}