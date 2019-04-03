using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tpd.Api.Core.Database;
using Tpd.Api.Core.DataTransferObject;

namespace Tpd.Api.Core.DataAccess
{
    //
    // Summary:
    //     A generic repository is the one that can be used for all the entities.
    //     This class will provide all basic method for accessing or updating a table of database.
    // Remarks:
    //     dataContext: A DbContext and can be used to query and save instances of entities.
    //     Dbset: A Dbset can be used to query and save instances of TEntity.
    //     context: The current context you are working on.
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
        //
        // Summary:
        //     Updates an entity data before update it's state to Microsoft.EntityFrameworkCore.EntityState.Added.
        //     The entity will be inserted into the database when Microsoft.EntityFrameworkCore.DbContext.SaveChanges
        //     is called.
        // Parameters:
        //     entity:
        //          The entity to add.
        //     context:
        //          The current context you are working on.
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
        //
        // Summary:
        //     Updates an entity data before update it's state to Microsoft.EntityFrameworkCore.EntityState.Added.
        //     The entity will be inserted into the database when Microsoft.EntityFrameworkCore.DbContext.SaveChanges
        //     is called.
        // Parameters:
        //     entity:
        //          The entity to add.
        //     context:
        //          The current context you are working on.
        public virtual async Task AddAsync(RequestContext context, T entity)
        {
            var currentDateTime = DateTime.Now;
            entity.CreatedAt = currentDateTime;
            entity.UpdatedAt = currentDateTime;
            //entity.CreatedBy = context.UserId;
            //entity.UpdatedBy = context.UserId;
            await Dbset.AddAsync(entity);
        }
        //
        // Summary:
        //     This function is soft delete an entity.
        //     Sets value of property IsDeleted of entity to True.
        //     The entity will be updated in the database when Microsoft.EntityFrameworkCore.DbContext.SaveChanges
        //     is called.
        // Parameters:
        //     entity:
        //          The entity to delete.
        //     context:
        //          The current context you are working on.
        public void Delete(RequestContext context, T entity)
        {
            entity.IsDeleted = true;
            Update(context, entity);
        }
        //
        // Summary:
        //     This function is soft delete an entity by it Id.
        //     Finds an entity will be deleted, then sets value of property IsDeleted of the entity to True.
        //     The entity will be updated in the database when Microsoft.EntityFrameworkCore.DbContext.SaveChanges
        //     is called.
        // Parameters:
        //     id:
        //          The Id of an entity to delete.
        //     context:
        //          The current context you are working on.
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
                query = query.Where(w => w.IsDeleted == false);
            }

            return query.FirstOrDefault();
        }

        public IQueryable<T> GetQuery(bool isCheckDeleted = true)
        {
            if (isCheckDeleted)
            {
                return Dbset.Where(w => !w.IsDeleted);
            }

            return Dbset.AsQueryable();
        }

        public void Update(RequestContext context, T entity)
        {
            entity.UpdatedAt = DateTime.Now;
            //entity.UpdatedBy = context.UserId;
            Dbset.Attach(entity);
            _dataContext.Entry(entity).State = EntityState.Modified;
        }

        public void BulkAdd(RequestContext context, IList<T> entities)
        {
            _dataContext.BulkInsert(entities);
        }

        public async void BulkAddAsync(RequestContext context, IList<T> entity)
        {
            await _dataContext.BulkInsertAsync(entity);
        }
    }
}
