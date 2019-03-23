using AutoMapper;
using Tpd.Api.Core.Interface.ControllerBases;

namespace Tpd.Api.Example.Interface.Controllers
{
    public class BaseMapperController : CoreBaseMapperController
    {
        public BaseMapperController(IMapper mapper) :
            base(mapper)
        {

        }
    }
}
