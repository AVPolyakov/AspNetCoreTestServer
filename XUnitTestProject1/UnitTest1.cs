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
        [Fact]
        public async Task Test1()
        {
            {
                var handler = TestServer1.CreateClient<IValuesHandler>(typeof(ValuesController));
                Assert.Equal("M2_value1_value2", await handler.M2("value2"));
            }
            {
                var handler = TestServer2.CreateClient<IValuesHandler>(typeof(ValuesController));
                Assert.Equal("M2_value3_value4", await handler.M2("value4"));
            }
        }

        private static TestServer TestServer1 => testServer1.Value;

        private static Lazy<TestServer> testServer1 => Lazy.Create(() => new TestServer(new WebHostBuilder()
            .AddStartupSettings(new StartupSettings {
                Provider1 = _ => _.AddTransient<IProvider1>(p => new TestProvider1("value1"))
            })
            .UseStartup<Startup>()));

        private static TestServer TestServer2 => testServer2.Value;

        private static Lazy<TestServer> testServer2 => Lazy.Create(() => new TestServer(new WebHostBuilder()
            .AddStartupSettings(new StartupSettings {
                Provider1 = _ => _.AddTransient<IProvider1>(p => new TestProvider1("value3"))
            })
            .UseStartup<Startup>()));
    }

    public class TestProvider1 : IProvider1
    {
        public string Value { get; }

        public TestProvider1(string value1)
        {
            Value = value1;
        }
    }
}
