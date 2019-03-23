using Microsoft.Extensions.DependencyInjection;
using Tpd.Api.Core.Interface;
using Tpd.Api.Database.Context;
using Tpd.Api.Example.DataAccess.UnitOfWork;

namespace Tpd.Api.Interface.App_Start
{
    public static class ConfigureServices
    {
        /// <summary>
        /// Configure Dependency Injection
        /// </summary>
        /// <param name="services"></param>
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            services.AddDependencyInjection(typeof(Example.Service.Service));
            services.AddTransient<DatabaseContext>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
