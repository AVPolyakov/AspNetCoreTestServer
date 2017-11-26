using AppServices;
using Microsoft.Extensions.DependencyInjection;

namespace WebApplication3
{
    public interface IStartupConfigurationService
    {
        void ConfigureServices(IServiceCollection services);
    }

    public class StartupConfigurationService : IStartupConfigurationService
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IXxxProvider, XxxProvider>();
        }
    }
}