using AutoMapper;
using Tpd.Api.Core.Interface;
using Tpd.Api.Interface.Models.MasterDataCategoryModels;
using Tpd.Api.Example.Service.Requests.Commands.MasterDataCategoryCommands;
using Tpd.Api.Example.Service.Requests.Queries.MasterDataCategoryQueties;
using Tpd.Api.Example.Service.ServiceResultModels;
using Microsoft.AspNetCore.Mvc;
using System;
using Tpd.Api.DataTransferObject;

namespace Tpd.Api.Example.Interface.Controllers
{
    /// <summary>
    /// Api for Master Data Category management
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class MasterDataCategoryController : BaseCrudController<
        DtoMasterDataCategory,
        MasterDataCategoryViewModel,
        MasterDataCategoryViewModel,
        MasterDataCategoryViewModel,
        MasterDataCategoryCreateModel,
        MasterDataCategoryCreateCommand,
        MasterDataCategoryUpdateModel,
        MasterDataCategoryUpdateCommand>
    {
        public MasterDataCategoryController(IMapper mapper)
            : base(mapper)
        {

        }

        /// <summary>
        /// Delete A Master Data Category
        /// </summary>
        /// <param name="model">Request Model with Master Data Category Id</param>
        /// <returns></returns>
        [HttpDelete]
        public ActionResult<ResponseModelBase> Delete(RequestModelBase<Guid> model)
        {
            //Call base function
            return DoCommand<Guid, MasterDataCategoryDeleteCommand>(model);
        }

        /// <summary>
        /// Get A Master Data Category
        /// </summary>
        /// <param name="id">Category Id</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public ActionResult<ResponseModelBase> GetItem(Guid id)
        {
            // Create a query object
            var query = new MasterDataCategoryGetItemQuery
            {
                Id = id
            };

            var result = DoQueryItem<MasterDataCategoryGetItemQuery, SrmMasterDataCategory, MasterDataCategoryViewModel>(query);

            return result;
        }

        /// <summary>
        /// Get List Of Master Data Category
        /// </summary>
        /// <param name="name">Category Name</param>
        /// <param name="description">Category description</param>
        /// <param name="skip">Bypasses a specified number of elements in a sequence 
        /// and then returns the remainingelements.</param>
        /// <param name="take">Returns a specified number of contiguous elements from the start of a sequence.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<ResponseModelBase> GetList(string name, string description, int skip, int take)
        {
            // Create a query object
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
