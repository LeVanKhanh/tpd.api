using Microsoft.EntityFrameworkCore;

namespace Tpd.Api.Core.Database
{
    public class DatabaseContextBase: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connstr = SingletonFactory.GetConnectionString;            
            optionsBuilder.UseSqlServer(connstr);
        }

        public void Commit()
        {
            SaveChanges();
        }
    }
}
