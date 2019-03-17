using ElmahCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using System.Collections.Generic;
using Tpd.Api.Utility.Serializer;

namespace Tpd.Api.Core.Interface
{
    public static class ConfigureApp
    {
        public static void UseGlobalException(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "application/json";

                    var error = context.Features.Get<IExceptionHandlerFeature>();
                    if (error != null)
                    {
                        //Write to log file
                        context.RiseError(error.Error);

                        var message = error.Error.Message;

                        var result = new ResponseModelBase
                        {
                            Success = false,
                            Message = new List<string>
                            {
                                message
                            }
                        };

                        context.Response.WriteJson(result);
                    }
                });
            });
        }

        public static void UseSwagger(this IApplicationBuilder app)
        {
            SwaggerBuilderExtensions.UseSwagger(app);
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                //To serve the Swagger UI at the app's root (http://localhost:<port>/)
                c.RoutePrefix = string.Empty;
            });
        }
    }
}
