using AutoMapper;
using Tpd.Api.Core.Interface;
using Tpd.Api.Interface.Models.MasterDataCategoryModels;
using Tpd.Api.Example.Service.Requests.Commands.MasterDataCategoryCommands;
using Tpd.Api.Example.Service.Requests.Queries.MasterDataCategoryQueties;
using System;

namespace Tpd.Api.Interface.AutoMapperProfiles
{
    public class RequestModelToCommand:Profile
    {
        /// <summary>
        /// Configure Auto Mapping
        /// Source: Request Model
        /// Destination: Command/ Query
        /// </summary>
        public RequestModelToCommand()
        {
            CreateMap<RequestModelBase<MasterDataCategoryCreateModel>, MasterDataCategoryCreateCommand>();
            CreateMap<RequestModelBase<MasterDataCategoryUpdateModel>, MasterDataCategoryUpdateCommand>();
            CreateMap<RequestModelBase<Guid>, MasterDataCategoryDeleteCommand>();
            CreateMap<RequestModelBase<Guid>, MasterDataCategoryGetItemQuery>();
        }
    }
}
