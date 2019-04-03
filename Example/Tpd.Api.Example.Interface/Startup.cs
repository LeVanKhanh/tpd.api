using AutoMapper;
using ElmahCore.Mvc;
using Tpd.Api.Core.Interface;
using Tpd.Api.Interface.App_Start;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Tpd.Api.Interface
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

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

            //services.AddHostedService<TimerSendCounted>();

        }

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
            // Implement SignalR
            app.UseSignalR();
        }
    }
}
