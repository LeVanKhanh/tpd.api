using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Tpd.Api.Core.Database;
using Tpd.Api.Core.DataTransferObject;

namespace Tpd.Api.Core.DataAccess
{
    public class RpstBase<T> : IRpstBase<T>
        where T : DtoBase
    {
        protected DbSet<T> Dbset;
        private DatabaseContextBase _dataContext;

        public RpstBase(DatabaseContextBase dataContext)
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

        public async void AddAsync(RequestContext context, T entity)
        {
            var currentDateTime = DateTime.Now;
            //entity.CreatedAt = currentDateTime;
            //entity.UpdatedAt = currentDateTime;
            //entity.CreatedBy = context.UserId;
            //entity.UpdatedBy = context.UserId;
            await Dbset.AddAsync(entity);
        }

        public void BulkAdd(RequestContext context, IList<T> entity)
        {
            _dataContext.BulkInsert(entity);
        }

        public async void BulkAddAsync(RequestContext context, IList<T> entity)
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
