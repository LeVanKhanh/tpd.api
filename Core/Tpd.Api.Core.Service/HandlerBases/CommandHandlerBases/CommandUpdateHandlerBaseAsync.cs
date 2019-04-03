using AutoMapper;
using System.Threading.Tasks;
using Tpd.Api.Core.DataAccess;
using Tpd.Api.Core.DataTransferObject;
using Tpd.Api.Core.Service.RequestBases.CommandBases;
using Tpd.Api.Core.Share;

namespace Tpd.Api.Core.Service.HandlerBases.CommandHandlerBases
{
    //
    // Summary:
    //     An class provide basic functions for handling a command update data.
    public class CommandUpdateHandlerBaseAsync<TCommand, TEntity, TDto> : CommandHandlerBaseAsyncTask<TCommand>
        where TCommand : ICommandUpdateBase<TDto>
        where TEntity : DtoBase
        where TDto : DtoBase
    {
        protected readonly IMapper Mapper;
        public CommandUpdateHandlerBaseAsync(IUnitOfWorkBase unitOfWork, IMapper mapper)
            : base(unitOfWork)
        {
            Mapper = mapper;
        }
        //
        // Summary:
        //     Tries to build a command to update entity in database.
        // Return:
        //     System.Boolean is build command success or not.
        protected override async Task<bool> TryBuildCommandAsync(TCommand command, RequestContext Context)
        {
            var repository = UnitOfWork.Repository<TEntity>();

            var oldEntity = await GetOldEntityAsync(repository, command);

            if (oldEntity == null)
            {
                command.Messages.Add(Constants.CommonMessages.THE_ITEM_DOES_NOT_EXIST);
                return false;
            }

            var newEntity = await CreateNewEntityAsync(oldEntity, command);
            repository.Update(Context, newEntity);
            return true;
        }
        //
        // Summary:
        //     Get an entity from database.
        // Return:
        //     The entity will be modified and updated to database.
        protected virtual async Task<TEntity> GetOldEntityAsync(IRpstBase<TEntity> repository, TCommand command)
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
        protected virtual async Task<TEntity> CreateNewEntityAsync(TEntity oldEntity, TCommand command)
        {
            var createdAt = oldEntity.CreatedAt;
            var entity = Mapper.Map(command.Model, oldEntity);
            entity.CreatedAt = createdAt;
            return entity;
        }
    }
}
