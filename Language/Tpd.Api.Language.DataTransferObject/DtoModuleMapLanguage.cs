using System;
using Tpd.Api.Core.DataTransferObject;

namespace Tpd.Api.Language.DataTransferObject
{
    public class DtoModuleMapLanguage : DtoBase
    {
        public Guid ModuleId { get; set; }
        public Guid BaselineId { get; set; }
    }
}
