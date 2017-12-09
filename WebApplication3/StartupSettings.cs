using System;
using AppServices;
using Microsoft.Extensions.DependencyInjection;

namespace WebApplication3
{
    public class StartupSettings
    {
        public Action<IServiceCollection> Provider1 = _ => _.AddTransient<IProvider1, Provider1>();
    }
}