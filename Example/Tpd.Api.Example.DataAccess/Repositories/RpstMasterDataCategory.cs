using Tpd.Api.Core.DataAccess;
using Tpd.Api.Database.Context;
using Tpd.Api.Database.Entities;

namespace Tpd.Api.Example.DataAccess.Repositories
{
    public class RpstMasterDataCategory : RpstBase<EttMasterDataCategory>
    {
        public RpstMasterDataCategory(DatabaseContext dataContext)
           : base(dataContext)
        {

        }
    }
}
