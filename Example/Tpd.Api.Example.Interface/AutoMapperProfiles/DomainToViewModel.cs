using AutoMapper;
using Tpd.Api.DataTransferObject;
using Tpd.Api.Example.Interface.Models.MasterDataCategoryModels;

namespace Tpd.Api.Example.Interface.AutoMapperProfiles
{
    public class DomainToViewModel : Profile
    {
        /// <summary>
        /// Config Auto Mapping
        /// Source: Domain Model/Service Model/ DTO
        /// Destination: View Model/ DTO
        /// </summary>
        public DomainToViewModel()
        {
            CreateMap<DtoMasterDataCategory, MasterDataCategoryViewModel>();
        }
    }
}
