using System;

namespace Tpd.Api.Interface.Models.MasterDataCategoryModels
{
    public class MasterDataCategoryUpdateModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
