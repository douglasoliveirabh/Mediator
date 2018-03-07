using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Mediator.Infra.CrossCutting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;

namespace Mediator.Api
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
            services.AddMvc();
            ConfigureSwagger(services);
            RegisterServices(services, Configuration);
        }

        private void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            Bootstrapper.RegisterServices(services, configuration, typeof(Startup));
        }

        private void ConfigureSwagger(IServiceCollection services)
        {

            var pathToDoc = Configuration["Swagger:FileName"];
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1",
                    new Info
                    {
                        Title = "Mediator Pattern Api Test",
                        Version = "v1",
                        Description = "A simple api to test mediator pattern",
                        TermsOfService = "None"
                    }
                 );

                var filePath = Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, pathToDoc);
                options.IncludeXmlComments(filePath);
                options.DescribeAllEnumsAsStrings();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseSwagger(c =>
            {
                c.PreSerializeFilters.Add((swagger, httpReq) => swagger.Host = httpReq.Host.Value);
            });

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "V1 Docs");
            });
        }


    }
}
