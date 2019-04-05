using Tpd.Api.Language.DataTransferObject;

namespace Tpd.Api.Language.Database.Entities
{
    public class EttTranslation: DtoTranslation
    {
        public EttLanguageBaseline Baseline { get; set; }
        public EttLanguage Language { get; set; }
    }
}
