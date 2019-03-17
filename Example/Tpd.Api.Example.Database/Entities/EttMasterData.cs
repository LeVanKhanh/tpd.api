using Tpd.Api.DataTransferObject;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tpd.Api.Database.Entities
{
    [Table("MasterData")]
    public class EttMasterData : DtoMasterData
    {
        public EttMasterDataCategory Category { get; set; }
    }
}
