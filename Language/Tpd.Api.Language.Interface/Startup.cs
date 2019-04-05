using AutoMapper;
using ElmahCore.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tpd.Api.Core.Interface;
using Tpd.Api.Language.Interface.App_Start;

namespace Tpd.Api.Language.Interface
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
            services.AddMvcOptions();
            services.AddAutoMapper();
            //Implement Swagger
            services.AddSwagger(typeof(Startup));
            //Config Dependency Injection
            services.AddDependencyInjection();
            //Implement Elmah
            services.AddElmahOptions();
            // Implement SignalR
            services.AddSignalR();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            //Implement Elmah
            app.UseElmah();
            // Implement Catch Global Exception
            app.UseGlobalException();
            app.UseStaticFiles();
            //Implement Swagger
            app.UseSwagger();
            app.UseHttpsRedirection();
            // Configure Cors Origins
            app.UseCorsOrigins();

            app.UseMvc();
        }
    }
}
