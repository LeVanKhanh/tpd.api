using Tpd.Api.Core.Service.RequestBases.QueryBases;

namespace Tpd.Api.Language.Service.Requests.Queries.LanguageByModule
{
    public class GetLanguageByModuleQuery: QueryListBase
    {
        public string Application { get; set; }
        public string Module { get; set; }
        public string Language { get; set; }
    }
}
