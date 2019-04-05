using Microsoft.Extensions.Configuration;
using System;

namespace Tpd.Api.Core.Interface
{
    public static class AppCoreSettings
    {
        public static string SystemTimeZone { get; private set; }

        static AppCoreSettings()
        {
            var builder = new ConfigurationBuilder()
                 .SetBasePath(AppContext.BaseDirectory)
                 .AddJsonFile("appsettings.json");

            IConfigurationRoot ConfigurationRoot = builder.Build();

            SystemTimeZone = ConfigurationRoot["SystemTimeZone"];
            if (string.IsNullOrEmpty(SystemTimeZone))
            {
                SystemTimeZone = TimeZoneInfo.Local.Id;
            }
        }
    }
}
