using Tpd.Api.Core.DataTransferObject;

namespace Tpd.Api.Example.Interface.Models.MasterDataCategoryModels
{
    public class MasterDataCategorySearchConditionModel : DtoPagingCondition
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
