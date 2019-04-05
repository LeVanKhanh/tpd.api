using System;
using Tpd.Api.Core.DataTransferObject;

namespace Tpd.Api.Language.DataTransferObject
{
    public class DtoTranslation : DtoBase
    {
        public Guid BaselineId { get; set; }
        public Guid LanguageId { get; set; }
        public string Display { get; set; }
    }
}
