using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tpd.Api.Core.Interface;
using Tpd.Api.Core.Interface.RequestModelBases;
using Tpd.Api.Language.DataTransferObject;
using Tpd.Api.Language.Interface.Models;
using Tpd.Api.Language.Service.Requests.Queries.LanguageByModule;

namespace Tpd.Api.Language.Interface.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageByModuleController : BaseMapperController
    {
        public LanguageByModuleController(IMapper mapper) : base(mapper)
        {

        }

        [HttpPost]
        [Route("GetLanguageByModule")]
        public ActionResult<ResponseModelBase> GetLanguageByModule([FromBody]RequestModelBase<GetLanguageByModuleModel> model)
        {
            var query = new GetLanguageByModuleQuery()
            {
                IsPaged = false,
                Application = model.Model.Application,
                Module = model.Model.Module,
                Language = model.RequestContext.Language
            };

            return DoQueryList<GetLanguageByModuleQuery, DtoLanguageByModule>(query);
        }
    }
}
