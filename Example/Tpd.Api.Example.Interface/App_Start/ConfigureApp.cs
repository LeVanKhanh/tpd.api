using Tpd.Api.Interface.Hubs;
using Microsoft.AspNetCore.Builder;

namespace Tpd.Api.Interface.App_Start
{
    public static class ConfigureApp
    {
        /// <summary>
        /// Configure Cors Origins
        /// </summary>
        /// <param name="app"></param>
        public static void UseCorsOrigins(this IApplicationBuilder app)
        {
            app.UseCors(builder =>
            {
                builder.WithOrigins("http://localhost:4200")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            });
        }

        /// <summary>
        /// Register SignalR Hub(s)
        /// </summary>
        /// <param name="app"></param>
        public static void UseSignalR(this IApplicationBuilder app)
        {
            app.UseSignalR(routes =>
            {
                routes.MapHub<ChatHub>("/chatHub");
            });
        }
    }
}
