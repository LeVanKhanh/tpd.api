using Microsoft.EntityFrameworkCore;

namespace Tpd.Api.Core.Database
{
    /// <summary>
    /// The class for DatabaseContext configuration
    /// </summary>
    public class DatabaseContextBase : DbContext
    {
        private readonly string _connectionStringName;

        public DatabaseContextBase(string connectionStringName = "DBConnection")
        {
            _connectionStringName = connectionStringName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connstr = ConnectionStringSettings.GetConnectionString(_connectionStringName);
            optionsBuilder.UseSqlServer(connstr);
        }
    }
}
