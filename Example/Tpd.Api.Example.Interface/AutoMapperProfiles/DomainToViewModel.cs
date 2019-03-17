using AutoMapper;
using Tpd.Api.Interface.Models.MasterDataCategoryModels;
using Tpd.Api.Example.Service.ServiceResultModels;

namespace Tpd.Api.Interface.AutoMapperProfiles
{
    public class DomainToViewModel: Profile
    {
        public DomainToViewModel()
        {
            CreateMap<SrmMasterDataCategory, MasterDataCategoryViewModel>();
        }
    }
}
