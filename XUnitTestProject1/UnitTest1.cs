using System;
using System.Threading.Tasks;
using AppServices;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using TypedHttpClient;
using WebApplication3;
using WebApplication3.Controllers;
using Xunit;

namespace XUnitTestProject1
{
    //A DIFFERENT APPROACH TO TEST YOUR ASP.NET CORE APPLICATION
    //http://geeklearning.io/a-different-approach-to-test-your-asp-net-core-application/
    public class Tests
    {
        private const string value1 = "value1";

        [Fact]
        public async Task Test1()
        {
            var value2 = "value2";
            var result = await handler.M2(value2);
            Assert.Equal($"M2_{value1}_{value2}", result);
        }

        private static readonly IValuesHandler handler = GetHandler();

        private static IValuesHandler GetHandler()
        {
            return new TestServer(new WebHostBuilder()
                    .ConfigureServices(
                        services => services.AddTransient<IStartupConfigurationService>(
                            provider => new TestStartupConfigurationService(() => value1)))
                    .UseStartup<Startup>())
                .CreateClient<IValuesHandler>(typeof(ValuesController));
        }
    }

    public class TestStartupConfigurationService : IStartupConfigurationService
    {
        private readonly Func<string> value;

        public TestStartupConfigurationService(Func<string> value)
        {
            this.value = value;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IXxxProvider>(provider => new TestXxxProvider(this));
        }

        public class TestXxxProvider : IXxxProvider
        {
            private readonly TestStartupConfigurationService startupConfigurationService;

            public TestXxxProvider(TestStartupConfigurationService startupConfigurationService)
            {
                this.startupConfigurationService = startupConfigurationService;
            }

            public string Value => startupConfigurationService.value();
        }
    }
}
