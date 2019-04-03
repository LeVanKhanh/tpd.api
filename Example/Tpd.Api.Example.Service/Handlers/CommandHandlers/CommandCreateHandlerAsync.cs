using AutoMapper;
using Tpd.Api.Core.DataTransferObject;
using Tpd.Api.Core.Service.HandlerBases.CommandHandlerBases;
using Tpd.Api.Core.Service.RequestBases.CommandBases;
using Tpd.Api.Example.DataAccess.UnitOfWork;

namespace Tpd.Api.Example.Service.Handlers.CommandHandlers
{
    public class CommandCreateHandlerAsync<TCommand, TEntity, TDto> : CommandCreateHandlerBaseAsync<TCommand, TEntity, TDto>
        where TCommand : ICommandCreateBase<TDto>
        where TEntity : DtoBase
        where TDto : DtoBase
    {
        protected new IUnitOfWork UnitOfWork { get; set; }
        public CommandCreateHandlerAsync(IUnitOfWork unitOfWork, IMapper mapper)
          : base(unitOfWork, mapper)
        {
            UnitOfWork = unitOfWork;
        }
    }
}
