using Microsoft.Extensions.DependencyInjection;
using Tpd.Api.Core.Interface;
using Tpd.Api.Language.DataAccess.UnitOfWork;
using Tpd.Api.Language.Database.Context;

namespace Tpd.Api.Language.Interface.App_Start
{
    public static class ConfigureServices
    {
        /// <summary>
        /// Configure Dependency Injection
        /// </summary>
        /// <param name="services"></param>
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            services.AddDependencyInjection(typeof(Service.Service));
            services.AddTransient<DatabaseContext>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
