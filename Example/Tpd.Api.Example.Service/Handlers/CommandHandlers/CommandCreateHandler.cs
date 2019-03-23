using AutoMapper;
using Tpd.Api.Core.Service.RequestBases.CommandBases;
using Tpd.Api.Core.Service.HandlerBases.CommandHandlerBases;
using Tpd.Api.Example.DataAccess.UnitOfWork;
using Tpd.Api.Core.DataTransferObject;

namespace Tpd.Api.Example.Service.Handlers.CommandHandlers
{
    public class CommandCreateHandler<TCommand, TEntity, TDto> : CommandCreateHandlerBase<TCommand, TEntity, TDto>
        where TCommand : ICommandCreateBase<TDto>
        where TEntity : DtoBase
        where TDto : DtoBase
    {
        protected new IUnitOfWork UnitOfWork { get; set; }
        public CommandCreateHandler(IUnitOfWork unitOfWork, IMapper mapper)
          : base(unitOfWork, mapper)
        {
            UnitOfWork = unitOfWork;
        }
    }
}
