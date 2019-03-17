using Tpd.Api.Core.Service.RequestBases.CommandBases;
using Tpd.Api.Core.Service.CommandResultBases;
using System.Threading.Tasks;


namespace Tpd.Api.Core.Service.HandlerBases.CommandHandlerBases
{
    public interface ICommandAsyncHandlerBase<in TCommand, TResultType>
        where TCommand : ICommandBase
    {
        Task<ICommandResultBase<TResultType>> Execute(TCommand command);
    }
}
