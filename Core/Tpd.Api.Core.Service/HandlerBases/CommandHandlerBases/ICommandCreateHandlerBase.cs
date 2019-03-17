using Tpd.Api.Core.Service.RequestBases.CommandBases;

namespace Tpd.Api.Core.Service.HandlerBases.CommandHandlerBases
{
    public interface ICommandCreateHandlerBase<TCommand, TResult> :
        ICommandHandlerBase<TCommand, TResult>
        where TCommand : ICommandBase
    {

    }
}
