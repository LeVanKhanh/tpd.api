using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tpd.Api.Core.Database;
using Tpd.Api.Language.Database.Entities;

namespace Tpd.Api.Language.Database.Context
{
    public partial class DatabaseContext : DatabaseContextBase
    {
        public void ConfigureApplication(EntityTypeBuilder<EttApplication> builder)
        {
            builder.Property(p => p.ShortName).HasMaxLength(50);
            builder.Property(p => p.FullName).HasMaxLength(200);
        }

        public void ConfigureLanguage(EntityTypeBuilder<EttLanguage> builder)
        {
            builder.Property(p => p.Code).HasMaxLength(50);
            builder.Property(p => p.Name).HasMaxLength(100);
        }

        public void ConfigureLanguageBaseLine(EntityTypeBuilder<EttLanguageBaseline> builder)
        {
            builder.Property(p => p.Code).HasMaxLength(500);
        }

        public void ConfigureModule(EntityTypeBuilder<EttModule> builder)
        {
            builder.Property(p => p.Name).HasMaxLength(200);
            builder.HasOne(o => o.Application).WithMany().HasForeignKey(f => f.ApplicationId);
        }

        public void ConfigureModuleMapLanguage(EntityTypeBuilder<EttModuleMapLanguage> builder)
        {
            builder.HasOne(o => o.Module).WithMany().HasForeignKey(f => f.ModuleId);
            builder.HasOne(o => o.Baseline).WithMany().HasForeignKey(f => f.BaselineId);
        }

        public void ConfigureTranslation(EntityTypeBuilder<EttTranslation> builder)
        {
            builder.HasOne(o => o.Baseline).WithMany().HasForeignKey(f => f.BaselineId);
            builder.HasOne(o => o.Language).WithMany().HasForeignKey(f => f.LanguageId);
        }
    }
}
