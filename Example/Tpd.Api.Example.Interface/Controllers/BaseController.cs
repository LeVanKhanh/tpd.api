using AutoMapper;
using Tpd.Api.Core.Interface;

namespace Tpd.Api.Interface.Controllers
{
    public class BaseController : CoreBaseController
    {
        public BaseController(IMapper mapper)
         : base(mapper)
        {

        }
    }
}
