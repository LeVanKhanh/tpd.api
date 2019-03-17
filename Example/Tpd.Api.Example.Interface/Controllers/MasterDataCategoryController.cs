using AutoMapper;
using Tpd.Api.Core.Interface;
using Tpd.Api.Interface.Models.MasterDataCategoryModels;
using Tpd.Api.Example.Service.Requests.Commands.MasterDataCategoryCommands;
using Tpd.Api.Example.Service.Requests.Queries.MasterDataCategoryQueties;
using Tpd.Api.Example.Service.ServiceResultModels;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Tpd.Api.Interface.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterDataCategoryController : BaseController
    {
        public MasterDataCategoryController(IMapper mapper)
            : base(mapper)
        {

        }

        [HttpPut]
        public ActionResult<ResponseModelBase> Create(RequestModelBase<MasterDataCategoryCreateModel> model)
        {
            return DoCommand<MasterDataCategoryCreateModel, MasterDataCategoryCreateCommand, bool>(model);
        }

        [HttpPost]
        public ActionResult<ResponseModelBase> Update(RequestModelBase<MasterDataCategoryUpdateModel> model)
        {
            return DoCommand<MasterDataCategoryUpdateModel, MasterDataCategoryUpdateCommand, bool>(model);
        }

        [HttpDelete]
        public ActionResult<ResponseModelBase> Delete(RequestModelBase<Guid> model)
        {
            return DoCommand<Guid, MasterDataCategoryDeleteCommand, bool>(model);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<ResponseModelBase> GetItem(Guid id)
        {
            var query = new MasterDataCategoryGetItemQuery
            {
                Id = id
            };

            var result = DoQueryItem<MasterDataCategoryGetItemQuery, SrmMasterDataCategory, MasterDataCategoryViewModel>(query);

            return result;
        }

        [HttpGet]
        public ActionResult<ResponseModelBase> GetList(string name, string description, int skip, int take)
        {
            var query = new MasterDataCategoryGetListQuery
            {
                Name = name,
                Description = description,
                OrderBy = "Name",
                Skip = skip,
                Take = take
            };

            var result = DoQueryList<MasterDataCategoryGetListQuery, SrmMasterDataCategory, MasterDataCategoryViewModel>(query);

            return result;
        }
    }
}
