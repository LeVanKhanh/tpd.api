using Tpd.Api.Language.DataTransferObject;

namespace Tpd.Api.Language.Database.Entities
{
    public class EttModuleMapLanguage: DtoModuleMapLanguage
    {
        public EttModule Module { get; set; }
        public EttLanguageBaseline Baseline { get; set; }
    }
}
