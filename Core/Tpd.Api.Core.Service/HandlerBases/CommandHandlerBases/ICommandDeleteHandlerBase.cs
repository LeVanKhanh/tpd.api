using Tpd.Api.Core.Service.RequestBases.CommandBases;

namespace Tpd.Api.Core.Service.HandlerBases.CommandHandlerBases
{
    public interface ICommandDeleteHandlerBase<TCommand> : ICommandHandlerBase<TCommand>
        where TCommand : ICommandDeleteBase
    {
    }
}
