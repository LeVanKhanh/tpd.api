using System.ComponentModel.DataAnnotations;

namespace Tpd.Api.Interface.Models.MasterDataCategoryModels
{
    public class MasterDataCategoryCreateModel
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
