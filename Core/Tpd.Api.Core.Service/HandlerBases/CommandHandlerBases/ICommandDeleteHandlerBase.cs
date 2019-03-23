using Tpd.Api.Core.Service.RequestBases.CommandBases;

namespace Tpd.Api.Core.Service.HandlerBases.CommandHandlerBases
{
    //
    // Summary:
    //     An class provide basic functions for handling a command update data.
    public interface ICommandDeleteHandlerBase<TCommand> : ICommandHandlerBase<TCommand>
        where TCommand : ICommandDeleteBase
    {
    }
}
