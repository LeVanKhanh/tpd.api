using Tpd.Api.Core.Service.RequestBases.CommandBases;
using Tpd.Api.Core.Service.CommandResultBases;

namespace Tpd.Api.Core.Service.HandlerBases.CommandHandlerBases
{
    public interface ICommandHandlerBase<in TCommand, TResultType>
        where TCommand : ICommandBase
    {
        ICommandResultBase<TResultType> Execute(TCommand command);
    }
}
