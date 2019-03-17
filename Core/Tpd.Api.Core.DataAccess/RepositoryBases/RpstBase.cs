using Tpd.Api.Core.Database;
using Tpd.Api.Core.DataTransferObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tpd.Api.Core.DataAccess
{
    public class RpstBase<T, TDbContext> : IRpstBase<T>
        where T : DtoBase
        where TDbContext : DatabaseContextBase
    {
        protected DbSet<T> Dbset;
        private TDbContext _dataContext;

        public RpstBase(TDbContext dataContext)
        {
            _dataContext = dataContext;
            Dbset = dataContext.Set<T>();
        }

        public void Add(RequestContext context, T entity)
        {
            var currentDateTime = DateTime.Now;
            //entity.CreatedAt = currentDateTime;
            //entity.UpdatedAt = currentDateTime;
            //entity.CreatedBy = context.UserId;
            //entity.UpdatedBy = context.UserId;
            Dbset.Add(entity);
        }

        public void BulkAdd(RequestContext context, IEnumerable<T> entity)
        {
            _dataContext.BulkInsert(entity);
        }

        public async void BulkAddAsync(IEnumerable<T> entity)
        {
            await _dataContext.BulkInsertAsync(entity);
        }

        public void Delete(RequestContext context, T entity)
        {
            //entity.IsDeleted = true;
            Update(context, entity);
        }

        public void Delete(RequestContext context, Guid id)
        {
            var entity = Dbset.Find(id);
            Delete(context, entity);
        }

        public T GetById(Guid id, bool isCheckDeleted = true)
        {
            var query = Dbset.Where(w => w.Id == id);
            if (isCheckDeleted)
            {
                //query = query.Where(w => w.IsDeleted == false);
            }

            return query.FirstOrDefault();
        }

        public IQueryable<T> GetQuery(bool isCheckDeleted = true)
        {
            if (isCheckDeleted)
            {
                //return Dbset.Where(w => !w.IsDeleted);
            }

            return Dbset.AsQueryable();
        }

        public void Update(RequestContext context, T entity)
        {
            //entity.UpdatedAt = DateTime.Now;
            //entity.UpdatedBy = context.UserId;
            Dbset.Update(entity);
        }
    }
}
