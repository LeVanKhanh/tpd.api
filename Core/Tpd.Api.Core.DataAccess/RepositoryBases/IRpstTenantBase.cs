using System.Linq;

namespace Tpd.Api.Core.DataAccess
{
    public interface IRpstTenantBase<T> : IRpstBase<T> 
        where T : class
    {
        /// <summary>
        /// Get query for current entity
        /// </summary>
        IQueryable<T> GetQuery(RequestContext context, bool isCheckDeleted = true);
    }
}
