using ElmahCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using System.Collections.Generic;
using Tpd.Api.Utility.Serializer;

namespace Tpd.Api.Core.Interface
{
    public static class ConfigureApp
    {
        /// <summary>
        /// The function for catch all exception
        /// </summary>
        /// <param name="app"></param>
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
                        //Write to log file (Elmah)
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

                        // Return custome
                        context.Response.WriteJson(result);
                    }
                });
            });
        }

        /// <summary>
        /// The function for Swagger configuration
        /// </summary>
        /// <param name="app"></param>
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
