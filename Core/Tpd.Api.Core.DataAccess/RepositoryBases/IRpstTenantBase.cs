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
    public interface IRpstTenantBase<T> : IRpstBase<T> 
        where T : class
    {
        IQueryable<T> GetQuery(RequestContext context, bool isCheckDeleted = true);
    }
}
