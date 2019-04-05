using System;
using Tpd.Api.Utility.SystemDateTime;

namespace Tpd.Api.Example.Interface.Models.MasterDataCategoryModels
{
    public class MasterDataCategoryViewModel : IConvertTimeZone
    {
        public MasterDataCategoryViewModel()
        {
            TestDate = DateTime.Now;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime TestDate { get; set; }

        //This function use generic convert.
        //Best Practic: Manual convert instead of generic convert.
        public void ConvertTimeZone(string globalTimeZone, string localTimeZone)
        {
            this.Localize(localTimeZone, globalTimeZone);
        }

        //public void ConvertTimeZone(string globalTimeZone, string localTimeZone)
        //{
        //    TestDate = TestDate.Localize(localTimeZone, globalTimeZone);
        //}
    }
}
