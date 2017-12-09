using System;
using Microsoft.Extensions.DependencyInjection;

namespace WebApplication3
{
    public delegate void Registration<T>(IServiceCollection services);

    public static class Registration
    {
        public static Registration<T> Create<T, TImplementation>() where T : class where TImplementation : class, T 
            => _ => _.AddTransient<T, TImplementation>();

        public static Registration<T> Create<T>(Func<IServiceProvider, T> implementationFactory) where T : class 
            => _ => _.AddTransient(implementationFactory);
    }
}