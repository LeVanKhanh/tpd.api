using Tpd.Api.Core.Database;
using Tpd.Api.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Tpd.Api.Database.Context
{
    public partial class DatabaseContext: DatabaseContextBase
    {
        public DbSet<EttMasterData> MasterData { get; set; }
        public DbSet<EttMasterDataCategory> MasterDataCategory { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureMasterDataCategory(modelBuilder.Entity<EttMasterDataCategory>());
            ConfigureMasterData(modelBuilder.Entity<EttMasterData>());
        }
    }
}
