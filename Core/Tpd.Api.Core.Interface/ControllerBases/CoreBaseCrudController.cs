using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using Tpd.Api.Core.DataTransferObject;
using Tpd.Api.Core.Service.RequestBases;
using Tpd.Api.Core.Service.RequestBases.CommandBases;
using Tpd.Api.Core.Service.RequestBases.QueryBases;

namespace Tpd.Api.Core.Interface.ControllerBases
{
    //
    // Summary:
    //     The Abstract controller provide base CRUD functions
    public abstract class CoreBaseCrudController<TDto, TViewModel, TSerachConditionModel, TCreateModel, TCreateCommand, TUpdateModel, TUpdateCommand, TDeleteCommand, TQueryList>
        : CoreBaseMapperController
        where TDto : DtoBase
        where TCreateCommand : ICommandCreateBase<TDto>
        where TUpdateCommand : ICommandUpdateBase<TDto>
        where TDeleteCommand : ICommandDeleteBase
        where TQueryList : IQueryListBase
    {
        public CoreBaseCrudController(IMapper mapper) : base(mapper)
        {

        }

        [HttpPut]
        public virtual ActionResult<ResponseModelBase> Create([FromBody]RequestModelBase<TCreateModel> model)
        {
            return DoCommand<TCreateModel, TCreateCommand>(model);
        }

        [HttpPost]
        public ActionResult<ResponseModelBase> Update([FromBody]RequestModelBase<TUpdateModel> model)
        {
            return DoCommand<TUpdateModel, TUpdateCommand>(model);
        }

        [HttpDelete]
        public ActionResult<ResponseModelBase> Delete([FromBody]RequestModelBase<Guid> model)
        {
            return DoCommand<Guid, TDeleteCommand>(model);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<ResponseModelBase> GetItem(Guid id)
        {
            return DoQueryItemById<TDto, TViewModel>(id);
        }

        [HttpPost]
        [Route("GetList")]
        public ActionResult<ResponseModelBase> GetList([FromBody]RequestModelBase<TSerachConditionModel> model)
        {
            TQueryList query = Mapper.Map<TQueryList>(model.Model);
            query.Context = Mapper.Map<RequestContextBase>(model.RequestContext);
            return DoQueryList<TQueryList, TDto, TViewModel>(query);
        }
    }
}
