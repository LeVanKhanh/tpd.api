using System;
using System.Collections.Generic;
using System.Linq;

namespace Tpd.Api.Core.DataAccess
{
    public interface IRpstBase<T> 
        where T : class
    {
        /// <summary>
        /// Add an entity
        /// </summary>
        /// <param name="context">Current context</param>
        /// <param name="entity">Entity Data</param>
        void Add(RequestContext context, T entity);
        /// <summary>
        ///  Add an entity Async
        /// </summary>
        /// <param name="context">Current context</param>
        /// <param name="entity">Entity Data</param>
        void AddAsync(RequestContext context, T entity);
        /// <summary>
        /// Add entities
        /// </summary>
        /// <param name="context">Current context</param>
        /// <param name="entities">Entities</param>
        void BulkAdd(RequestContext context, IList<T> entity);
        /// <summary>
        /// Add entities async
        /// </summary>
        /// <param name="context">Current context</param>
        /// <param name="entity">Entities</param>
        void BulkAddAsync(RequestContext context, IList<T> entity);
        /// <summary>
        /// Update an entity
        /// </summary>
        /// <param name="context">Current context</param>
        /// <param name="entity">Entity Data</param>
        void Update(RequestContext context, T entity);
        /// <summary>
        /// Delete entity 
        /// </summary>
        /// <param name="context">Current context</param>
        /// <param name="entity">Entities</param>
        void Delete(RequestContext context, T entity);
        /// <summary>
        /// Delete entity by given Id
        /// </summary>
        /// <param name="context">Current context</param>
        /// <param name="id">Entity Id</param>
        void Delete(RequestContext context, Guid id);
        /// <summary>
        /// Get an entity by Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="isCheckDeleted"></param>
        /// <returns></returns>
        T GetById(Guid id, bool isCheckDeleted = true);
        /// <summary>
        /// Get query for current entity
        /// </summary>
        IQueryable<T> GetQuery(bool isCheckDeleted = true);
    }
}
