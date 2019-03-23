using Tpd.Api.Core.Service.RequestBases.CommandBases;
using System.Threading.Tasks;
using Tpd.Api.Core.Service.ResultBases;

namespace Tpd.Api.Core.Service.HandlerBases.CommandHandlerBases
{
    public interface ICommandAsyncHandlerBase<TCommand>
        where TCommand : ICommandBase
    {
        // Base function for execute a command
        Task<IResultBase<int>> HandleAsync(TCommand command);
    }
}
