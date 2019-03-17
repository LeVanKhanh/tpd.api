using System;
using System.Linq;

namespace Tpd.Api.Core.DataAccess
{
    public interface IRpstTenantBase<T> : IRpstBase<T> 
        where T : class
    {
        IQueryable<T> GetQueryByTenant(Guid tenantId, bool isCheckDeleted = true);
    }
}
