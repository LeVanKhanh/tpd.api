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

        /// <summary>
        /// Add an entity
        /// </summary>
        /// <param name="context">Current context</param>
        /// <param name="entity">Entity Data</param>
        public virtual void Add(RequestContext context, T entity)
        {
            var currentDateTime = DateTime.Now;
            entity.CreatedAt = currentDateTime;
            entity.UpdatedAt = currentDateTime;
            //entity.CreatedBy = context.UserId;
            //entity.UpdatedBy = context.UserId;

            if (entity.Id == Guid.Empty)
            {
                entity.Id = Guid.NewGuid();
            }

            Dbset.Add(entity);
        }

        /// <summary>
        ///  Add an entity Async
        /// </summary>
        /// <param name="context">Current context</param>
        /// <param name="entity">Entity Data</param>
        public virtual async void AddAsync(RequestContext context, T entity)
        {
            var currentDateTime = DateTime.Now;
            entity.CreatedAt = currentDateTime;
            entity.UpdatedAt = currentDateTime;
            //entity.CreatedBy = context.UserId;
            //entity.UpdatedBy = context.UserId;
            await Dbset.AddAsync(entity);
        }

        /// <summary>
        /// Add entities
        /// </summary>
        /// <param name="context">Current context</param>
        /// <param name="entities">Entities</param>
        public void BulkAdd(RequestContext context, IList<T> entities)
        {
            _dataContext.BulkInsert(entities);
        }

        /// <summary>
        /// Add entities async
        /// </summary>
        /// <param name="context">Current context</param>
        /// <param name="entity">Entities</param>
        public async void BulkAddAsync(RequestContext context, IList<T> entity)
        {
            await _dataContext.BulkInsertAsync(entity);
        }

        /// <summary>
        /// Delete entity 
        /// </summary>
        /// <param name="context">Current context</param>
        /// <param name="entity">Entities</param>
        public void Delete(RequestContext context, T entity)
        {
            entity.IsDeleted = true;
            Update(context, entity);
        }

        /// <summary>
        /// Delete entity by given Id
        /// </summary>
        /// <param name="context">Current context</param>
        /// <param name="id">Entity Id</param>
        public void Delete(RequestContext context, Guid id)
        {
            var entity = Dbset.Find(id);
            Delete(context, entity);
        }

        /// <summary>
        /// Get an entity by Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="isCheckDeleted"></param>
        /// <returns></returns>
        public T GetById(Guid id, bool isCheckDeleted = true)
        {
            var query = Dbset.Where(w => w.Id == id);
            if (isCheckDeleted)
            {
                query = query.Where(w => w.IsDeleted == false);
            }

            return query.FirstOrDefault();
        }

        /// <summary>
        /// Get query for current entity
        /// </summary>
        /// <param name="isCheckDeleted">Get items were marked deleted or not</param>
        /// <returns></returns>
        public IQueryable<T> GetQuery(bool isCheckDeleted = true)
        {
            if (isCheckDeleted)
            {
                return Dbset.Where(w => !w.IsDeleted);
            }

            return Dbset.AsQueryable();
        }

        /// <summary>
        /// Update an entity
        /// </summary>
        /// <param name="context">Current context</param>
        /// <param name="entity">Entity Data</param>
        public void Update(RequestContext context, T entity)
        {
            entity.UpdatedAt = DateTime.Now;
            //entity.UpdatedBy = context.UserId;
            Dbset.Update(entity);
        }
    }
}
