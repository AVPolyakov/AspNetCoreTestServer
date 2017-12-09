using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace WebApplication3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .AddStartupSettings(new StartupSettings())
                .UseStartup<Startup>()
                .Build();
        }
    }
}
