using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tpd.Api.Core.Database;
using Tpd.Api.Core.DataTransferObject;

namespace Tpd.Api.Core.DataAccess
{
    //
    // Summary:
    //     A abstract class provide fuctions/DbSets to work with database
    public abstract class UnitOfWorkBase : IUnitOfWorkBase
    {
        protected DatabaseContextBase DataContext { get; set; }
        protected Dictionary<string, object> Repositories { get; set; }

        public UnitOfWorkBase(DatabaseContextBase dataContext)
        {
            DataContext = dataContext;
            Repositories = new Dictionary<string, object>();
        }

        public int Commit()
        {
            return DataContext.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            return await DataContext.SaveChangesAsync();
        }
        //
        // Summary:
        //     A function can be used to get a repository of an entity
        // Parameters:
        //     TEntity:
        //          Type of an entity
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

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if (DataContext != null)
                DataContext.Dispose();
        }
    }
}
