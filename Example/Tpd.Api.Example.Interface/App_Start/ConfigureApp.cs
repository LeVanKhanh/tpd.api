using Tpd.Api.Interface.Hubs;
using Microsoft.AspNetCore.Builder;

namespace Tpd.Api.Interface.App_Start
{
    public static class ConfigureApp
    {
        public static void UseCorsOrigins(this IApplicationBuilder app)
        {
            app.UseCors(builder =>
            {
                builder.WithOrigins("https://localhost:44330",
                    "http://localhost:44361",
                    "http://localhost:4200",
                    "http://localhost:92")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            });
        }

        public static void UseSignalR(this IApplicationBuilder app)
        {
            app.UseSignalR(routes =>
            {
                routes.MapHub<ChatHub>("/chatHub");
            });
        }
    }
}
