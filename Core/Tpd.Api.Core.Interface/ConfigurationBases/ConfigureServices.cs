using ElmahCore;
using ElmahCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;
using System.Reflection;
using NetCore.AutoRegisterDi;

namespace Tpd.Api.Core.Interface
{
    public static class ConfigureServices
    {
        public static void AddMvcOptions(this IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.Filters.Add(new ActionExceptionFilterAttribute());
                options.Filters.Add(new ActionFilterAttribute());
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public static void AddSwagger(this IServiceCollection services, Type type)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "ToDo API",
                    Description = "A simple example ASP.NET Core Web API",
                    TermsOfService = "None",
                    Contact = new Contact
                    {
                        Name = "Shayne Boyer",
                        Email = string.Empty,
                        Url = "https://twitter.com/spboyer"
                    },
                    License = new License
                    {
                        Name = "Use under LICX",
                        Url = "https://example.com/license"
                    }
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetAssembly(type).GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        public static void AddElmahOptions(this IServiceCollection services)
        {
            string path = Path.Combine(AppContext.BaseDirectory, "logs");
            services.AddElmah<XmlFileErrorLog>(options =>
            {
                options.LogPath = path;// The path to write file
                options.Path = @"errors";// the route name
            });
        }

        public static void AddDependencyInjection(this IServiceCollection services, Type type)
        {
            var assemblyToScan = Assembly.GetAssembly(type); //..or whatever assembly you need

            services.RegisterAssemblyPublicNonGenericClasses(assemblyToScan)
              .Where(c => c.Name.EndsWith("Handler"))
              .AsPublicImplementedInterfaces();
        }
    }
}
