using Tpd.Api.Core.Service.RequestBases.CommandBases;
using Tpd.Api.Core.Service.ResultBases;

namespace Tpd.Api.Core.Service.HandlerBases.CommandHandlerBases
{
    public interface ICommandHandlerBase<TCommand>
        where TCommand : ICommandBase
    {
        // Base function for execute a command
        IResultBase<int> Handle(TCommand command);
    }
}
