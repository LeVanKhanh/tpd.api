using AutoMapper;
using System.Collections.Generic;
using Tpd.Api.Core.DataAccess;
using Tpd.Api.Core.DataTransferObject;
using Tpd.Api.Core.Service.RequestBases.CommandBases;
using Tpd.Api.Core.Share;

namespace Tpd.Api.Core.Service.HandlerBases.CommandHandlerBases
{
    public class CommandUpdateHandlerBase<TCommand, TEntity, TDto> : CommandHandlerBase<TCommand>, 
        ICommandUpdateHandlerBase<TCommand, TDto>
        where TCommand : ICommandUpdateBase<TDto>
        where TEntity : DtoBase
        where TDto : DtoBase
    {

        protected readonly IMapper Mapper;
        public CommandUpdateHandlerBase(IUnitOfWorkBase unitOfWork, IMapper mapper)
            : base(unitOfWork)
        {
            Mapper = mapper;
        }

        protected override bool TryBuildCommand(TCommand command, RequestContext Context, out List<string> messages)
        {
            messages = new List<string>();

            var repository = UnitOfWork.Repository<TEntity>();

            var oldEntity = GetOldEntity(repository, command);

            if (oldEntity == null)
            {
                messages.Add(Constants.CommonMessages.THE_ITEM_DOES_NOT_EXIST);
                return false;
            }

            var newEntity = CreateNewEntity(oldEntity, command);
            repository.Update(Context, newEntity);
            return true;
        }

        protected virtual TEntity GetOldEntity(IRpstBase<TEntity> repository, TCommand command)
        {
            return repository.GetById(command.Model.Id);
        }

        protected virtual TEntity CreateNewEntity(TEntity oldEntity, TCommand command)
        {
            var entity = Mapper.Map<TEntity>(command.Model);
            entity.CreatedAt = oldEntity.CreatedAt;
            return entity;
        }
    }
}
