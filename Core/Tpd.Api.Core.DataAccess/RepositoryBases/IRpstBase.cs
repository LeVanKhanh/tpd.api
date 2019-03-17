using System;
using System.Collections.Generic;
using System.Linq;

namespace Tpd.Api.Core.DataAccess
{
    public interface IRpstBase<T> 
        where T : class
    {
        void Add(RequestContext context, T entity);
        void AddAsync(RequestContext context, T entity);
        void BulkAdd(RequestContext context, IList<T> entity);
        void BulkAddAsync(RequestContext context, IList<T> entity);
        void Update(RequestContext context, T entity);
        void Delete(RequestContext context, T entity);
        T GetById(Guid id, bool isCheckDeleted = true);
        IQueryable<T> GetQuery(bool isCheckDeleted = true);
    }
}
