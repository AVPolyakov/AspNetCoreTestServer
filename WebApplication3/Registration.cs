using System;
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
}