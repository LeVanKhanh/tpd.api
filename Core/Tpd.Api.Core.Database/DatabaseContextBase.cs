using Microsoft.EntityFrameworkCore;

namespace Tpd.Api.Core.Database
{
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

        public void Commit()
        {
            SaveChanges();
        }
    }
}
