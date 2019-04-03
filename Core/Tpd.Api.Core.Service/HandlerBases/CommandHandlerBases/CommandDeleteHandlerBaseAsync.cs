using AutoMapper;
using System.Threading.Tasks;
using Tpd.Api.Core.DataAccess;
using Tpd.Api.Core.DataTransferObject;
using Tpd.Api.Core.Service.RequestBases.CommandBases;
using Tpd.Api.Core.Share;

namespace Tpd.Api.Core.Service.HandlerBases.CommandHandlerBases
{
    public class CommandDeleteHandlerBaseAsync<TCommand, TEntity> : CommandHandlerBaseAsyncTask<TCommand>
        where TCommand : ICommandDeleteBase
        where TEntity : DtoBase
    {
        protected readonly IMapper Mapper;
        public CommandDeleteHandlerBaseAsync(IUnitOfWorkBase unitOfWork, IMapper mapper)
            : base(unitOfWork)
        {
            Mapper = mapper;
        }
        //
        // Summary:
        //     Tries to build a command to delete an entity in database.
        // Return:
        //     System.Boolean is build command success or not.
        protected override async Task<bool> TryBuildCommandAsync(TCommand command, RequestContext Context)
        {

            var repository = UnitOfWork.Repository<TEntity>();

            var deleteEntity = await GetDeleteEntityAsync(repository, command);

            if (deleteEntity == null)
            {
                command.Messages.Add(Constants.CommonMessages.THE_ITEM_DOES_NOT_EXIST);
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
        protected virtual async Task<TEntity> GetDeleteEntityAsync(IRpstBase<TEntity> repository, TCommand command)
        {
            return repository.GetById(command.Model);
        }
    }
}
