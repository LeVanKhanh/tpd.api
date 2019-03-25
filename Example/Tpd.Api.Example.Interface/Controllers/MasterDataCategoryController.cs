using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tpd.Api.DataTransferObject;
using Tpd.Api.Example.Interface.Models.MasterDataCategoryModels;
using Tpd.Api.Example.Service.Requests.Commands.MasterDataCategoryCommands;
using Tpd.Api.Example.Service.Requests.Queries.MasterDataCategoryQueries;

namespace Tpd.Api.Example.Interface.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterDataCategoryController : BaseCrudController<DtoMasterDataCategory,
        MasterDataCategoryViewModel, 
        MasterDataCategorySearchConditionModel,
        MasterDataCategoryCreateModel, MasterDataCategoryCreateCommand,
        MasterDataCategoryUpdateModel, MasterDataCategoryUpdateCommand,
        MasterDataCategoryDeleteCommand, MasterDataCategoryGetListQuery>
    {
        public MasterDataCategoryController(IMapper mapper)
            : base(mapper)
        {

        }
    }
}
