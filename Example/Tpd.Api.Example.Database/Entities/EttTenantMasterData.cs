using Tpd.Api.DataTransferObject;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tpd.Api.Database.Entities
{
    [Table("TenantMasterData")]
    public class EttTenantMasterData : DtoTenantMasterData
    {
        public EttMasterData MasterData { get; set; }
    }
}
