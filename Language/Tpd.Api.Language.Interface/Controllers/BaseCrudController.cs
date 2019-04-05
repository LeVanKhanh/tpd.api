using AutoMapper;
using Tpd.Api.Core.DataTransferObject;
using Tpd.Api.Core.Interface.ControllerBases;
using Tpd.Api.Core.Service.RequestBases.CommandBases;
using Tpd.Api.Core.Service.RequestBases.QueryBases;

namespace Tpd.Api.Language.Interface.Controllers
{
    public class BaseCrudController<TDto, TViewModle, TSerachConditionModel, TCreateModel, TCreateCommand, TUpdateModel, TUpdateCommand, TDeleteCommand, TQueryList>
               : CoreBaseCrudController<TDto, TViewModle, TSerachConditionModel, TCreateModel, TCreateCommand, TUpdateModel, TUpdateCommand, TDeleteCommand, TQueryList>
        where TDto : DtoBase
        where TCreateCommand : ICommandCreateBase<TDto>
        where TUpdateCommand : ICommandUpdateBase<TDto>
        where TDeleteCommand : ICommandDeleteBase
        where TQueryList : IQueryListBase
    {
        public BaseCrudController(IMapper mapper) :
            base(mapper)
        {

        }
    }
}
