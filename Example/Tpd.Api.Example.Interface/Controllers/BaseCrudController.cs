using AutoMapper;
using Tpd.Api.Core.DataTransferObject;
using Tpd.Api.Core.Interface.ControllerBases;
using Tpd.Api.Core.Service.RequestBases.CommandBases;

namespace Tpd.Api.Example.Interface.Controllers
{
    public class BaseCrudController<TDto, TItemViewModel, TSearchViewModel, TSerachConditionModel, TCreateModel, TCreateCommand, TUpdateModel, TUpdateCommand>
               : CoreCrudController<TDto, TItemViewModel, TSearchViewModel, TSerachConditionModel, TCreateModel, TCreateCommand, TUpdateModel, TUpdateCommand>
        where TDto : DtoBase
        where TCreateCommand : ICommandCreateBase<TDto>
        where TUpdateCommand : ICommandUpdateBase<TDto>
    {
        public BaseCrudController(IMapper mapper) :
            base(mapper)
        {

        }
    }
}
