using Tpd.Api.Core.Service.RequestBases.CommandBases;

namespace Tpd.Api.Core.Service.HandlerBases.CommandHandlerBases
{
    public interface ICommandHandlerBaseAsyncVoid<TCommand>
        where TCommand : ICommandBase
    {
        void HandleAsyncVoid(TCommand command);
    }
}