using AutoMapper;
using System.Collections.Generic;
using Tpd.Api.Core.DataAccess;
using Tpd.Api.Core.DataTransferObject;
using Tpd.Api.Core.Service.RequestBases.CommandBases;

namespace Tpd.Api.Core.Service.HandlerBases.CommandHandlerBases
{
    public class CommandCreateAsyncHandlerBase<TCommand, TEntity, TDto> :
        CommandAsyncHandlerBase<TCommand>,
        ICommandCreateAsyncHandlerBase<TCommand, TDto>
        where TCommand : ICommandCreateBase<TDto>
        where TEntity : DtoBase
        where TDto : DtoBase
    {

        protected readonly IMapper Mapper;
        public CommandCreateAsyncHandlerBase(IUnitOfWorkBase unitOfWork, IMapper mapper)
            : base(unitOfWork)
        {
            Mapper = mapper;
        }

        protected override bool TryBuildCommand(TCommand command, RequestContext Context, out List<string> messages)
        {
            messages = new List<string>();
            var repository = UnitOfWork.Repository<TEntity>();
            var entity = CreateEntity(command);
            repository.Add(Context, entity);
            return true;
        }

        protected TEntity CreateEntity(TCommand command)
        {
            return Mapper.Map<TEntity>(command.Model);
        }
    }
}
