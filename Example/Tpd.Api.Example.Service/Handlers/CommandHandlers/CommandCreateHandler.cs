using AutoMapper;
using Tpd.Api.Core.Service.RequestBases.CommandBases;
using Tpd.Api.Core.Service.HandlerBases.CommandHandlerBases;
using Tpd.Api.Example.DataAccess.UnitOfWork;

namespace Tpd.Api.Example.Service.Handlers.CommandHandlers
{
    public abstract class CommandCreateHandler<TCommand, TResultType> : CommandCreateHandlerBase<TCommand, TResultType>
        where TCommand : ICommandBase
        where TResultType : new()
    {
        protected new IUnitOfWork UnitOfWork { get; set; }
        public CommandCreateHandler(IUnitOfWork unitOfWork, IMapper mapper)
          : base(unitOfWork, mapper)
        {
            UnitOfWork = unitOfWork;
        }
    }
}
