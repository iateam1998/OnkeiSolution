using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OnkeiSolutionLib;
using Swashbuckle.AspNetCore.Swagger;

namespace OnkeiSolution
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var fileDirectory = System.AppDomain.CurrentDomain.BaseDirectory + "SaveFolder";
            if (!Directory.Exists(fileDirectory))
                Directory.CreateDirectory(fileDirectory);

            RootConfig.Entry(services, Configuration);
            #region Swagger Config
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("onkeiapi"
                    , new Info
                    {
                        Title = "Onkei Solution"
                        ,
                        Version = "v1.0"
                        ,
                        Description = "ASP.NET Core Onkei Solution API",
                    });
                var xmlFile = System.AppDomain.CurrentDomain.BaseDirectory + $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlFile);
            });
            #endregion
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseHttpsRedirection();

            #region Swagger Config
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/onkeiapi/swagger.json", "Onkei Solution API V1.0");
                c.RoutePrefix = string.Empty;
            });
            #endregion
            app.UseMvc();
        }
    }
}
