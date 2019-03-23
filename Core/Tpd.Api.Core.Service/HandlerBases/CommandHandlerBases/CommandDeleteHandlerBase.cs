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
    public class CommandDeleteHandlerBase<TCommand, TEntity> : CommandHandlerBase<TCommand>
        where TCommand : ICommandDeleteBase
        where TEntity : DtoBase
    {
        protected readonly IMapper Mapper;
        public CommandDeleteHandlerBase(IUnitOfWorkBase unitOfWork, IMapper mapper)
            : base(unitOfWork)
        {
            Mapper = mapper;
        }
        //
        // Summary:
        //     Tries to build a command to delete an entity in database.
        // Return:
        //     System.Boolean is build command success or not.
        protected override bool TryBuildCommand(TCommand command, RequestContext Context, out List<string> messages)
        {
            messages = new List<string>();

            var repository = UnitOfWork.Repository<TEntity>();

            var deleteEntity = GetDeleteEntity(repository, command);

            if (deleteEntity == null)
            {
                messages.Add(Constants.CommonMessages.THE_ITEM_DOES_NOT_EXIST);
                return false;
            }

            repository.Delete(Context, deleteEntity);
            return true;
        }
        //
        // Summary:
        //     Get an entity from database.
        // Return:
        //     The entity will be deleted in database.
        protected virtual TEntity GetDeleteEntity(IRpstBase<TEntity> repository, TCommand command)
        {
            return repository.GetById(command.Model);
        }
    }
}
