using Tpd.Api.Core.DataTransferObject;
using System;

namespace Tpd.Api.DataTransferObject
{
    public class DtoTenantMasterData : DtoTenantBase
    {
        public Guid MasterDataId { get; set; }
    }
}
