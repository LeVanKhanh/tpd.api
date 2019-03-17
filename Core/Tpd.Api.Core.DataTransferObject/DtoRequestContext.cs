using System;

namespace Tpd.Api.Core.DataTransferObject
{
    public class DtoRequestContext
    {
        public DtoRequestContext()
        {
            UserId = Guid.NewGuid();
            TenantId = Guid.NewGuid();
        }

        public Guid UserId { get; set; }
        public Guid TenantId { get; set; }
    }
}
