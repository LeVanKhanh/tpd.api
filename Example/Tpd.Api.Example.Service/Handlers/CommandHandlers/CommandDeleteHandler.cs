using AutoMapper;
using Tpd.Api.Core.DataTransferObject;
using Tpd.Api.Core.Service.HandlerBases.CommandHandlerBases;
using Tpd.Api.Core.Service.RequestBases.CommandBases;
using Tpd.Api.Example.DataAccess.UnitOfWork;

namespace Tpd.Api.Example.Service.Handlers.CommandHandlers
{
    public class CommandDeleteHandler<TCommand, TEntity> : CommandDeleteHandlerBase<TCommand, TEntity>
        where TCommand : ICommandDeleteBase
        where TEntity : DtoBase
    {
        protected new IUnitOfWork UnitOfWork { get; set; }
        public CommandDeleteHandler(IUnitOfWork unitOfWork, IMapper mapper)
          : base(unitOfWork, mapper)
        {
            UnitOfWork = unitOfWork;
        }
    }
}
