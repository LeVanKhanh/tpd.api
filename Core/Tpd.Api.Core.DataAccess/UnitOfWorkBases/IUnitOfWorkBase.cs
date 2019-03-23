using System.Threading.Tasks;
using Tpd.Api.Core.DataTransferObject;

namespace Tpd.Api.Core.DataAccess
{
    public interface IUnitOfWorkBase
    {
        /// <summary>
        /// The function for getting Repository by type of Entity
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        IRpstBase<TEntity> Repository<TEntity>() where TEntity : DtoBase;
        /// <summary>
        /// Commit change
        /// </summary>
        int Commit();
        /// <summary>
        /// Commit change async
        /// </summary>
        Task<int> CommitAsync();
    }
}
