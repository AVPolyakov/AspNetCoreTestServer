using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace WebApplication3
{
    public class Startup
    {
        private readonly IStartupConfigurationService configurationService;

        public Startup(IConfiguration configuration, IStartupConfigurationService configurationService)
        {
            this.configurationService = configurationService;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IValuesHandler, ValuesHandler>();
            configurationService.ConfigureServices(services);
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
