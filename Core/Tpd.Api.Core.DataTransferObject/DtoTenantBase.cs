using System;

namespace Tpd.Api.Core.DataTransferObject
{
    public class DtoTenantBase : DtoBase
    {
        public Guid TenantId { get; set; }
    }
}
