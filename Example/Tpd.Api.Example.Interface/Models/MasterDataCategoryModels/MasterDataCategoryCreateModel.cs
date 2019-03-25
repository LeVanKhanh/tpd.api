﻿using System.ComponentModel.DataAnnotations;

namespace Tpd.Api.Example.Interface.Models.MasterDataCategoryModels
{
    public class MasterDataCategoryCreateModel
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
