using Tpd.Api.Core.DataAccess;
using Tpd.Api.Language.Database.Context;
using Tpd.Api.Language.Database.Entities;

namespace Tpd.Api.Language.DataAccess.Repositories
{
    public class RpstLanguageBaseLine : RpstBase<EttLanguageBaseline>
    {
        public RpstLanguageBaseLine(DatabaseContext dataContext)
            : base(dataContext)
        {

        }
    }
}
