using System;
using Tpd.Api.Core.DataTransferObject;

namespace Tpd.Api.Language.DataTransferObject
{
    public class DtoModule : DtoBase
    {
        public Guid ApplicationId { get; set; }
        public string Name { get; set; }
    }
}
