using Microsoft.Extensions.DependencyInjection;
using Tpd.Api.Core.Interface;
using Tpd.Api.Database.Context;
using Tpd.Api.Example.DataAccess.UnitOfWork;

namespace Tpd.Api.Interface.App_Start
{
    public static class ConfigureServices
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            services.AddDependencyInjection(typeof(Example.Service.Service));
            services.AddTransient<DatabaseContext>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
