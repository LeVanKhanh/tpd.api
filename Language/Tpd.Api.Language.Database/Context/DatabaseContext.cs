using Microsoft.EntityFrameworkCore;
using Tpd.Api.Core.Database;
using Tpd.Api.Language.Database.Entities;

namespace Tpd.Api.Language.Database.Context
{
    public partial class DatabaseContext: DatabaseContextBase
    {
        public DbSet<EttApplication> Application { get; set; }
        public DbSet<EttLanguage> Language { get; set; }
        public DbSet<EttLanguageBaseline> LanguageBaseLine { get; set; }
        public DbSet<EttModule> Module { get; set; }
        public DbSet<EttModuleMapLanguage> ModuleMapLanguage { get; set; }
        public DbSet<EttTranslation> Translation { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureApplication(modelBuilder.Entity<EttApplication>());
            ConfigureLanguage(modelBuilder.Entity<EttLanguage>());
            ConfigureLanguageBaseLine(modelBuilder.Entity<EttLanguageBaseline>());
            ConfigureModule(modelBuilder.Entity<EttModule>());
            ConfigureModuleMapLanguage(modelBuilder.Entity<EttModuleMapLanguage>());
            ConfigureTranslation(modelBuilder.Entity<EttTranslation>());
        }
    }
}
