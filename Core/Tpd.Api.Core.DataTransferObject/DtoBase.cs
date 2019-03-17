using System;

namespace Tpd.Api.Core.DataTransferObject
{
    public class DtoBase
    {
        public DtoBase()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        //public DateTime CreatedAt { get; set; }
        //public DateTime UpdatedAt { get; set; }
        //public Guid CreatedBy { get; set; }
        //public Guid UpdatedBy { get; set; }
        //public bool IsDeleted { get; set; }
    }
}
