using Tpd.Api.Core.Service.HandlerBases.CommandHandlerBases;
using Tpd.Api.Core.Service.RequestBases.CommandBases;
using Tpd.Api.Example.DataAccess.UnitOfWork;

namespace Tpd.Api.Example.Service.Handlers.CommandHandlers
{
    public abstract class CommandHandlerAsync<TCommand> : CommandHandlerBase<TCommand>
        where TCommand : ICommandBase
    {
        protected new IUnitOfWork UnitOfWork { get; set; }
        public CommandHandlerAsync(IUnitOfWork unitOfWork)
          : base(unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
    }
}
