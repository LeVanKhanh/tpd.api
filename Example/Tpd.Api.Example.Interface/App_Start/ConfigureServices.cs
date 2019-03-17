using Tpd.Api.Example.DataAccess.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;
using Tpd.Api.Core.Interface;

namespace Tpd.Api.Interface.App_Start
{
    public static class ConfigureServices
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            services.AddDependencyInjection(typeof(Example.Service.Service));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
