using Tpd.Api.Core.DataTransferObject;

namespace Tpd.Api.Core.DataAccess
{
    public interface IUnitOfWorkBase
    {
        IRpstBase<TEntity> Repository<TEntity>() where TEntity : DtoBase;
        void Commit();
        void CommitAsync();
    }
}
