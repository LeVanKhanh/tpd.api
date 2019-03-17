using Tpd.Api.Core.DataAccess;
using Tpd.Api.Database.Context;
using Tpd.Api.Database.Entities;

namespace Tpd.Api.Example.DataAccess.Repositories
{
    public class RpstMasterData : RpstBase<EttMasterData>
    {
        public RpstMasterData(DatabaseContext dataContext)
            : base(dataContext)
        {

        }
    }
}
