using Tpd.Api.Core.DataAccess;
using Tpd.Api.Core.Database;
using Tpd.Api.Database.Entities;

namespace Tpd.Api.Example.DataAccess.Repositories
{
    public class RpstBleSignal : RpstBase<EttBleSignal, DatabaseContextBase>
    {
        public RpstBleSignal(DatabaseContextBase dataContext)
            : base(dataContext)
        {

        }
    }
}
