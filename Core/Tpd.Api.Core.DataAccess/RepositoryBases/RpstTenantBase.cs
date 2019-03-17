using Tpd.Api.Core.Database;
using Tpd.Api.Core.DataTransferObject;
using System;
using System.Linq;

namespace Tpd.Api.Core.DataAccess
{
    public class RpstTenantBase<T> : RpstBase<T>, IRpstTenantBase<T>
         where T : DtoTenantBase
    {
        public RpstTenantBase(DatabaseContextBase dataContext)
            : base(dataContext)
        {

        }

        public void AddByTeant(RequestContext context, Guid TenantId, T entity)
        {
            entity.TenantId = Guid.NewGuid();
            Add(context, entity);
        }

        public IQueryable<T> GetQueryByTenant(Guid tenantId, bool isCheckDeleted = true)
        {
            var query = Dbset.Where(w => w.TenantId == tenantId);
            if (isCheckDeleted)
            {
                //return Dbset.Where(w => !w.IsDeleted);
            }

            return query;
        }
    }
}
