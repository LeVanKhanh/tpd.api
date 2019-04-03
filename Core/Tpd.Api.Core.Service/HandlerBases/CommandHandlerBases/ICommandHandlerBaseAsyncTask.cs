using System.Threading.Tasks;
using Tpd.Api.Core.Service.RequestBases.CommandBases;
using Tpd.Api.Core.Service.ResultBases;

namespace Tpd.Api.Core.Service.HandlerBases.CommandHandlerBases
{
    public interface ICommandHandlerBaseAsyncTask<TCommand>
        where TCommand : ICommandBase
    {
        Task<IResultBase<int>> HandleAsyncTask(TCommand command);
    }
}