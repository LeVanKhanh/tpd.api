using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
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

        [HttpPut]
        [Route("CreateAsync")]
        public virtual async Task<ActionResult<ResponseModelBase>> CreateAsync([FromBody]RequestModelBase<TCreateModel> model)
        {
            return await DoCommandAsyncTask<TCreateModel, TCreateCommand>(model);
        }

        [HttpPost]
        public ActionResult<ResponseModelBase> Update([FromBody]RequestModelBase<TUpdateModel> model)
        {
            return DoCommand<TUpdateModel, TUpdateCommand>(model);
        }

        [HttpPost]
        [Route("UpdateAsync")]
        public async Task<ActionResult<ResponseModelBase>> UpdateAsync([FromBody]RequestModelBase<TUpdateModel> model)
        {
            return await DoCommandAsyncTask<TUpdateModel, TUpdateCommand>(model);
        }

        [HttpDelete]
        public ActionResult<ResponseModelBase> Delete([FromBody]RequestModelBase<Guid> model)
        {
            return DoCommand<Guid, TDeleteCommand>(model);
        }

        [HttpDelete]
        [Route("DeleteAsync")]
        public async Task<ActionResult<ResponseModelBase>> DeleteAsync([FromBody]RequestModelBase<Guid> model)
        {
            return await DoCommandAsyncTask<Guid, TDeleteCommand>(model);
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

        [HttpPost]
        [Route("GetListAsync")]
        public async Task<ActionResult<ResponseModelBase>> GetListAsync([FromBody]RequestModelBase<TSerachConditionModel> model)
        {
            TQueryList query = Mapper.Map<TQueryList>(model.Model);
            query.Context = Mapper.Map<RequestContextBase>(model.RequestContext);
            return await DoQueryListAsync<TQueryList, TDto, TViewModel>(query);
        }
    }
}
