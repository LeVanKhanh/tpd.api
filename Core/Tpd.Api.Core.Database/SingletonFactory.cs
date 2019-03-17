using Microsoft.Extensions.Configuration;
using System;

namespace Tpd.Api.Core.Database
{
    public class SingletonFactory
    {
        private static string _connectionString;
        private static readonly object padlock = new object();

        SingletonFactory()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("connectionstrings.json");

            var config = builder.Build();
            _connectionString = config.GetConnectionString("DBConnection");
        }

        public static string GetConnectionString
        {
            get
            {
                lock (padlock)
                {
                    if (_connectionString == null)
                    {
                        new SingletonFactory();
                    }
                    return _connectionString;
                }
            }
        }
    }
}
