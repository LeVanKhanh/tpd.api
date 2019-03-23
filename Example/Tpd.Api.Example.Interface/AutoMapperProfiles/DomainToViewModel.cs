using AutoMapper;
using Tpd.Api.Interface.Models.MasterDataCategoryModels;
using Tpd.Api.Example.Service.ServiceResultModels;

namespace Tpd.Api.Interface.AutoMapperProfiles
{
    public class DomainToViewModel: Profile
    {
        /// <summary>
        /// Config Auto Mapping
        /// Source: Domain Model/Service Model/ DTO
        /// Destination: View Model/ DTO
        /// </summary>
        public DomainToViewModel()
        {
            CreateMap<SrmMasterDataCategory, MasterDataCategoryViewModel>();
        }
    }
}
