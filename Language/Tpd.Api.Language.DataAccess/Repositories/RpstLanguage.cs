using Tpd.Api.Core.DataAccess;
using Tpd.Api.Language.Database.Context;
using Tpd.Api.Language.Database.Entities;

namespace Tpd.Api.Language.DataAccess.Repositories
{
    public class RpstLanguage : RpstBase<EttLanguage>
    {
        public RpstLanguage(DatabaseContext dataContext)
            : base(dataContext)
        {

        }
    }
}
