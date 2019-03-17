using Tpd.Api.Core.DataAccess;
using Tpd.Api.Core.Database;
using Tpd.Api.Database.Context;
using Tpd.Api.Database.Entities;

namespace Tpd.Api.Example.DataAccess.Repositories
{
    public class RpstMasterData : RpstBase<EttMasterData, DatabaseContextBase>
    {
        public RpstMasterData(DatabaseContextBase dataContext)
            : base(dataContext)
        {

        }
    }
}
