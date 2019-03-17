using Tpd.Api.Core.Database;
using Tpd.Api.Database.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Tpd.Api.Database.Context
{
    public partial class DatabaseContext : DatabaseContextBase
    {
        public void ConfigureMasterData(EntityTypeBuilder<EttMasterData> builder)
        {
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(1000);
            builder.Property(p => p.CategoryId).IsRequired();
            builder.HasOne(o => o.Category).WithMany().HasForeignKey(f => f.CategoryId);
        }

        public void ConfigureMasterDataCategory(EntityTypeBuilder<EttMasterDataCategory> builder)
        {
            builder.Property(p => p.Name).IsRequired().HasMaxLength(200);
            builder.Property(p => p.Description).HasMaxLength(1000);
        }
    }
}
