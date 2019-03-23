using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tpd.Api.Core.DataTransferObject;
using Tpd.Api.Core.Service.RequestBases.CommandBases;

namespace Tpd.Api.Core.Interface.ControllerBases
{
    public class CoreCrudController<
        TDto,
        TItemViewModel,
        TSearchViewModel,
        TSerachConditionModel,
        TCreateModel,
        TCreateCommand,
        TUpdateModel,
        TUpdateCommand> : CoreBaseMapperController
        where TDto : DtoBase
        where TCreateCommand : ICommandCreateBase<TDto>
        where TUpdateCommand: ICommandBase
    {
        public CoreCrudController(IMapper mapper) : base(mapper)
        {

        }

        [HttpPut]
        public virtual ActionResult<ResponseModelBase> Create(RequestModelBase<TCreateModel> model)
        {
            return DoCommand<TCreateModel, TCreateCommand>(model);
        }

        [HttpPost]
        public ActionResult<ResponseModelBase> Update(RequestModelBase<TUpdateModel> model)
        {
            return DoCommand<TUpdateModel, TUpdateCommand>(model);
        }

        //[HttpDelete]
        //public ActionResult<ResponseModelBase> Delete(RequestModelBase<Guid> model)
        //{
        //    //Call base function
        //    //return DoCommand<Guid, MasterDataCategoryDeleteCommand>(model);
        //}

        //[HttpGet]
        //[Route("{id}")]
        //public ActionResult<ResponseModelBase> GetItem(Guid id)
        //{
        //    // Create a query object
        //    var query = new MasterDataCategoryGetItemQuery
        //    {
        //        Id = id
        //    };

        //    var result = DoQueryItem<MasterDataCategoryGetItemQuery, SrmMasterDataCategory, MasterDataCategoryViewModel>(query);

        //    return result;
        //}
    }
}
