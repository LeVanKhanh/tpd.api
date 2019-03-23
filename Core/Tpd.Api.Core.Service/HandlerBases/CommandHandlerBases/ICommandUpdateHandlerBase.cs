using Tpd.Api.Core.DataTransferObject;
using Tpd.Api.Core.Service.RequestBases.CommandBases;

namespace Tpd.Api.Core.Service.HandlerBases.CommandHandlerBases
{
    public interface ICommandUpdateHandlerBase<TCommand, TDto> : ICommandHandlerBase<TCommand>
        where TDto : DtoBase
        where TCommand : ICommandUpdateBase<TDto>
    {

    }
}
