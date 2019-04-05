using System;
using System.ComponentModel.DataAnnotations;
using Tpd.Api.Utility.SystemDateTime;

namespace Tpd.Api.Example.Interface.Models.MasterDataCategoryModels
{
    public class MasterDataCategoryCreateModel : IConvertTimeZone
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime TestDate { get; set; }

        ////This function use generic convert.
        ////Best Practic: Manual convert instead of generic convert.
        //public void ConvertTimeZone(string globalTimeZone, string localTimeZone)
        //{
        //    this.Globalize(localTimeZone, globalTimeZone);
        //}

        public void ConvertTimeZone(string globalTimeZone, string localTimeZone)
        {
            TestDate = TestDate.Convert(localTimeZone, globalTimeZone);
        }
    }
}
