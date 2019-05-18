﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using DKBS.Data;
using DKBS.Infrastructure.Sharepoint;
using DKBS.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;
using Swashbuckle.AspNetCore.Swagger;

namespace DKBS.API
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }
        readonly string AllowOrigins = "_allowOrigins";
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
            services.AddScoped<ISharepointService, SharepointService>();
            services.AddAutoMapper(cfg => { cfg.ValidateInlineMaps = false; });
            services.AddCors(options =>
            {
                options.AddPolicy(AllowOrigins,
                builder =>
                {
                    builder.AllowAnyOrigin();
                    builder.AllowAnyMethod();
                    builder.AllowAnyHeader();
                });
            });
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.Authority = string.Format(Configuration["AzureAd:AadInstance"], Configuration["AzureAd:Tenant"]);
                options.Audience = Configuration["AzureAd:Audience"];
                options.TokenValidationParameters.ValidateLifetime = true;
                options.TokenValidationParameters.ClockSkew = TimeSpan.Zero;
            });
            services.AddAuthorization();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSwaggerGen(c =>
            {
                //The generated Swagger JSON file will have these properties.
                c.SwaggerDoc("v1", new Info
                {
                    Title = "DKBS API Help",
                    Version = "v1",
                });
                //Locate the XML file being generated by ASP.NET...
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                //... and tell Swagger to use those XML comments.
                c.IncludeXmlComments(xmlPath);
                c.AddSecurityDefinition("oauth2", new ApiKeyScheme()
                {
                    Description = "Standard Authorization header using the Bearer scheme. Example: \"bearer {token}\"",
                    In = "header",
                    Name = "Authorization",
                    Type = "apiKey"
                });
            });

            Mapper.Initialize(cfg =>
                    cfg.AddProfiles(new[] {
                        "DKBS.API",
                        "DKBS.Repository"
                    }));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseFileServer();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseCors(AllowOrigins);
            app.UseAuthentication();
            app.UseMvc();

            //This line enables the app to use Swagger, with the configuration in the ConfigureServices method.
            app.UseSwagger();

            //This line enables Swagger UI, which provides us with a nice, simple UI with which we can view our API calls.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "DKBS API Help");
            });
        }
    }

}
