using Tpd.Api.Core.DataAccess;
using Tpd.Api.Core.Database;
using Tpd.Api.Database.Entities;

namespace Tpd.Api.Example.DataAccess.Repositories
{
    public class RpstMasterDataCategory : RpstBase<EttMasterDataCategory, DatabaseContextBase>
    {
        public RpstMasterDataCategory(DatabaseContextBase dataContext)
           : base(dataContext)
        {

        }
    }
}
