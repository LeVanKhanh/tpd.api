using Tpd.Api.Core.DataTransferObject;
using Tpd.Api.Core.Service.RequestBases.CommandBases;

namespace Tpd.Api.Core.Service.HandlerBases.CommandHandlerBases
{
    //
    // Summary:
    //     An class provide basic functions for handling a command update data.
    public interface ICommandUpdateHandlerBase<TCommand, TDto> : ICommandHandlerBase<TCommand>
        where TDto : DtoBase
        where TCommand : ICommandUpdateBase<TDto>
    {

    }
}
