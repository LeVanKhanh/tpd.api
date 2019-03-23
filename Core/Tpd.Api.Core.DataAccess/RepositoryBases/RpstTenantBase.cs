using System.Linq;
using Tpd.Api.Core.Database;
using Tpd.Api.Core.DataTransferObject;

namespace Tpd.Api.Core.DataAccess
{
    //
    // Summary:
    //     A generic repository is the one that can be used for all the entities.
    //     This class will provide all basic method for accessing or updating a table of database wich
    //     implement multi-tenancy
    // Remarks:
    //     dataContext: A DbContext and can be used to query and save instances of entities.
    //     Dbset: A Dbset can be used to query and save instances of TEntity.
    //     context: The current context you are working on.
    public class RpstTenantBase<T> : RpstBase<T>, IRpstTenantBase<T>
         where T : DtoTenantBase
    {
        public RpstTenantBase(DatabaseContextBase dataContext)
            : base(dataContext)
        {

        }

        public override void Add(RequestContext context, T entity)
        {
            entity.TenantId = context.TenantId;
            Add(context, entity);
        }

        public override void AddAsync(RequestContext context, T entity)
        {
            entity.TenantId = context.TenantId;
            AddAsync(context, entity);
        }

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
