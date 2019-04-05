using Tpd.Api.Core.DataTransferObject;

namespace Tpd.Api.Language.DataTransferObject
{
    public class DtoLanguageBaseline: DtoBase
    {
        public string Code { get; set; }
        public string Display { get; set; }
        public string Description { get; set; }
    }
}
