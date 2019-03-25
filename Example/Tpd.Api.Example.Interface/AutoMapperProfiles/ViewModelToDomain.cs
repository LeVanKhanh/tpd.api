using AutoMapper;
using Tpd.Api.Core.Interface;
using Tpd.Api.Core.Service.RequestBases;
using Tpd.Api.DataTransferObject;
using Tpd.Api.Example.Interface.Models.MasterDataCategoryModels;

namespace Tpd.Api.Example.Interface.AutoMapperProfiles
{
    public class ViewModelToDomain: Profile
    {
        /// <summary>
        ///  Configure Auto Mapping
        ///  Source: View Model/ DTO
        ///  Destination: Domain model/ Service Model/ DTO
        /// </summary>
        public ViewModelToDomain()
        {
            CreateMap<MasterDataCategoryUpdateModel, DtoMasterDataCategory>();
            CreateMap<MasterDataCategoryCreateModel, DtoMasterDataCategory>();
            CreateMap<RequestContext, RequestContextBase>();
            CreateMap<RequestContextBase, RequestContext>();
        }
    }
}
