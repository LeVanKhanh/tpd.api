using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace Tpd.Api.Core.Database
{
    /// <summary>
    /// The class for getting and storing all connectionstrings
    /// </summary>
    public static class ConnectionStringSettings
    {
        private static Dictionary<string, string> ConnectionStrings { get; set; }

        static ConnectionStringSettings()
        {
            ConnectionStrings = new Dictionary<string, string>();

            var builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("connectionstrings.json");
            var config = builder.Build();
            var connectionStrings = config.GetSection("ConnectionStrings").GetChildren();

            foreach (var connectionString in connectionStrings)
            {
                ConnectionStrings[connectionString.Key] = connectionString.Value;
            }
        }

        public static string GetConnectionString(string connectionStringName)
        {
            string connectionString;
            if(!ConnectionStrings.TryGetValue(connectionStringName, out connectionString))
            {
                connectionString = string.Empty;
            }
            return connectionString;
        }

    }
}
