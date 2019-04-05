using AutoMapper;
using Tpd.Api.Core.Interface;
using Tpd.Api.Example.Interface.Models.MasterDataCategoryModels;
using Tpd.Api.Example.Service.Requests.Commands.MasterDataCategoryCommands;
using Tpd.Api.Example.Service.Requests.Queries.MasterDataCategoryQueries;
using System;
using Tpd.Api.Core.Interface.RequestModelBases;

namespace Tpd.Api.Example.Interface.AutoMapperProfiles
{
    public class ClientRequestModelToServiceRequest:Profile
    {
        public ClientRequestModelToServiceRequest()
        {
            CreateMap<RequestModelBase<MasterDataCategoryCreateModel>, MasterDataCategoryCreateCommand>();
            CreateMap<RequestModelBase<MasterDataCategoryUpdateModel>, MasterDataCategoryUpdateCommand>();
            CreateMap<MasterDataCategorySearchConditionModel, MasterDataCategoryGetListQuery>();
            CreateMap<RequestModelBase<Guid>, MasterDataCategoryDeleteCommand>();
            CreateMap<RequestModelBase<Guid>, MasterDataCategoryGetItemQuery>();
        }
    }
}
