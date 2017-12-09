using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace WebApplication3
{
    public static class WebHostBuilderExtensions
    {
        public static IWebHostBuilder AddStartupSettings<T>(this IWebHostBuilder hostBuilder, T startupSettings) where T : class 
            => hostBuilder.ConfigureServices(sc => sc.AddTransient(p => startupSettings));
    }
}