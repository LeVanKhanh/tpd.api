using System;
using System.Collections.Generic;
using System.Linq;

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
    public interface IRpstBase<T> 
        where T : class
    {
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
        void Add(RequestContext context, T entity);
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
        void AddAsync(RequestContext context, T entity);
      
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
        void Delete(RequestContext context, T entity);
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
        void Delete(RequestContext context, Guid id);
       
        T GetById(Guid id, bool isCheckDeleted = true);
        
        IQueryable<T> GetQuery(bool isCheckDeleted = true);

        void Update(RequestContext context, T entity);

        void BulkAdd(RequestContext context, IList<T> entity);

        void BulkAddAsync(RequestContext context, IList<T> entity);
    }
}
