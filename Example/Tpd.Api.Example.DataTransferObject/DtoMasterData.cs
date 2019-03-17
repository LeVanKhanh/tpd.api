using Tpd.Api.Core.DataTransferObject;
using System;

namespace Tpd.Api.DataTransferObject
{
    public class DtoMasterData : DtoBase
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Sequence { get; set; }
        public bool IsActive { get; set; }
    }
}
