using System.Linq;
using Tpd.Api.Core.Database;
using Tpd.Api.Core.DataTransferObject;

namespace Tpd.Api.Core.DataAccess
{
    public class RpstTenantBase<T> : RpstBase<T>, IRpstTenantBase<T>
         where T : DtoTenantBase
    {
        public RpstTenantBase(DatabaseContextBase dataContext)
            : base(dataContext)
        {

        }

        /// <summary>
        /// Add an entity
        /// </summary>
        /// <param name="context">Current context</param>
        /// <param name="entity">Entity Data</param>
        public override void Add(RequestContext context, T entity)
        {
            entity.TenantId = context.TenantId;
            Add(context, entity);
        }

        /// <summary>
        ///  Add an entity Async
        /// </summary>
        /// <param name="context">Current context</param>
        /// <param name="entity">Entity Data</param>
        public override void AddAsync(RequestContext context, T entity)
        {
            entity.TenantId = context.TenantId;
            AddAsync(context, entity);
        }

        /// <summary>
        /// Get query for current entity
        /// </summary>
        /// <param name="context">Current context</param>
        /// <param name="isCheckDeleted">Get items were marked deleted or not</param>
        /// <returns></returns>
        public IQueryable<T> GetQuery(RequestContext context, bool isCheckDeleted = true)
        {
            var query = Dbset.Where(w => w.TenantId == context.TenantId);

            if (isCheckDeleted)
            {
                return Dbset.Where(w => !w.IsDeleted);
            }

            return query;
        }
    }
}
