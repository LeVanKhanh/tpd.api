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
            services.AddSwagger(typeof(Startup));
            services.AddDependencyInjection();
            services.AddElmahOptions();
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

            app.UseElmah();
            app.UseGlobalException();
            app.UseStaticFiles();
            app.UseSwagger();
            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseCorsOrigins();
            app.UseSignalR();
        }
    }
}
