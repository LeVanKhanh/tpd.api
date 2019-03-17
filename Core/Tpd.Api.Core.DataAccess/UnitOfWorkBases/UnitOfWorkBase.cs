using Tpd.Api.Core.Database;
using Tpd.Api.Core.DataTransferObject;

namespace Tpd.Api.Core.DataAccess
{
    public abstract class UnitOfWorkBase : IUnitOfWorkBase
    {
        public abstract IRpstBase<TEntity> Repository<TEntity>() where TEntity : DtoBase;
        protected DatabaseContextBase DataContext { get; set; }

        public void Commit()
        {
            DataContext.SaveChanges();
        }

        public async void CommitAsync()
        {
            await DataContext.SaveChangesAsync();
        }
    }
}
