using AutoMapper;
using System.Collections.Generic;
using Tpd.Api.Core.DataAccess;
using Tpd.Api.Core.DataTransferObject;
using Tpd.Api.Core.Service.RequestBases.CommandBases;
using Tpd.Api.Core.Share;

namespace Tpd.Api.Core.Service.HandlerBases.CommandHandlerBases
{
    //
    // Summary:
    //     An class provide basic functions for handling a command update data.
    public class CommandUpdateHandlerBase<TCommand, TEntity, TDto> : CommandHandlerBase<TCommand> 
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
        //
        // Summary:
        //     Tries to build a command to update entity in database.
        // Return:
        //     System.Boolean is build command success or not.
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
        //
        // Summary:
        //     Get an entity from database.
        // Return:
        //     The entity will be modified and updated to database.
        protected virtual TEntity GetOldEntity(IRpstBase<TEntity> repository, TCommand command)
        {
            return repository.GetById(command.Model.Id);
        }
        //
        // Summary:
        //     Gets data from command then create an entity.
        //     By default, this fuction using auto mapper to create entity.
        //     Derived can override this fuction to implement differnt way to create an entity.
        // Return:
        //     TEntity: Tpd.Api.Core.DataTransferObject.DtoBase an entity will be updated into data base.
        protected virtual TEntity CreateNewEntity(TEntity oldEntity, TCommand command)
        {
            var entity = Mapper.Map<TEntity>(command.Model);
            entity.CreatedAt = oldEntity.CreatedAt;
            return entity;
        }
    }
}
