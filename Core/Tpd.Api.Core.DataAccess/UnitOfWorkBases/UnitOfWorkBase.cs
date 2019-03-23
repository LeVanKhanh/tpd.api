using System.Collections.Generic;
using System.Threading.Tasks;
using Tpd.Api.Core.Database;
using Tpd.Api.Core.DataTransferObject;

namespace Tpd.Api.Core.DataAccess
{
    public abstract class UnitOfWorkBase : IUnitOfWorkBase
    {
        protected DatabaseContextBase DataContext { get; set; }
        protected Dictionary<string, object> Repositories { get; set; }

        public UnitOfWorkBase(DatabaseContextBase dataContext)
        {
            DataContext = dataContext;
            Repositories = new Dictionary<string, object>();
        }

        /// <summary>
        /// Commit change
        /// </summary>
        public int Commit()
        {
           return DataContext.SaveChanges();
        }

        /// <summary>
        /// Commit change async
        /// </summary>
        public async Task<int> CommitAsync()
        {
           return await DataContext.SaveChangesAsync();
        }

        /// <summary>
        /// The function for getting Repository by type of Entity
        /// </summary>
        /// <typeparam name="TEntity">Type of Entity</typeparam>
        /// <returns>
        /// Repository Base
        /// </returns>
        public virtual IRpstBase<TEntity> Repository<TEntity>()
            where TEntity : DtoBase
        {
            object repository;
            string key = typeof(TEntity).ToString();
            if (!Repositories.TryGetValue(key, out repository))
            {
                repository = new RpstBase<TEntity>(DataContext);
                Repositories[key] = repository;
            }
            return (IRpstBase<TEntity>)repository;
        }
    }
}
