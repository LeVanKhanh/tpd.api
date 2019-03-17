using System.Collections.Generic;
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

        public void Commit()
        {
            DataContext.SaveChanges();
        }

        public async void CommitAsync()
        {
            await DataContext.SaveChangesAsync();
        }

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
