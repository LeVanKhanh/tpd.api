using Tpd.Api.Core.DataTransferObject;

namespace Tpd.Api.Language.DataTransferObject
{
    public class DtoApplication : DtoBase
    {
        public string ShortName { get; set; }
        public string FullName { get; set; }
        public string Description { get; set; }
    }
}
