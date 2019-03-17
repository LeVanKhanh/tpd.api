using AutoMapper;
using Tpd.Api.Core.Interface;
using Tpd.Api.Core.Service.RequestBases;
using Tpd.Api.DataTransferObject;
using Tpd.Api.Interface.Models.MasterDataCategoryModels;

namespace Tpd.Api.Interface.AutoMapperProfiles
{
    public class ViewModelToDomain: Profile
    {
        public ViewModelToDomain()
        {
            CreateMap<MasterDataCategoryUpdateModel, DtoMasterDataCategory>();
            CreateMap<MasterDataCategoryCreateModel, DtoMasterDataCategory>();
            CreateMap<RequestContext, RequestContextBase>();
            CreateMap<RequestContextBase, RequestContext>();
        }
    }
}
