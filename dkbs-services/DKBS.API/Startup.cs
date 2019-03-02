using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DKBS.Data;
using DKBS.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;

namespace DKBS.API
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }

        public static readonly LoggerFactory DbCommandDebugLoggerFactory
            = new LoggerFactory(new[] {
                  new DebugLoggerProvider(
                      (category, level) => category == DbLoggerCategory.Database.Command.Name &&
                             level == LogLevel.Information) });

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
             .SetBasePath(env.ContentRootPath)
             .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
             .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
             .AddEnvironmentVariables();
            Configuration = builder.Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<DKBSDbContext>(options => 
            options.UseSqlServer(Configuration.GetConnectionString("DKBSConnectionString"))
            .UseLoggerFactory(DbCommandDebugLoggerFactory).EnableSensitiveDataLogging());
            services.AddScoped<IChoiceRepository, ChoiceRepository>();
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
