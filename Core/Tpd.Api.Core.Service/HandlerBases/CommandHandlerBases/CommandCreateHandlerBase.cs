using AutoMapper;
using Tpd.Api.Core.DataAccess;
using Tpd.Api.Core.DataTransferObject;
using Tpd.Api.Core.Service.RequestBases.CommandBases;
using Tpd.Api.Core.Share;

namespace Tpd.Api.Core.Service.HandlerBases.CommandHandlerBases
{
    public abstract class CommandCreateHandlerBase<TCommand, TResultType> :
        CommandHandlerBase<TCommand, TResultType>,
        ICommandCreateHandlerBase<TCommand, TResultType>
        where TCommand : ICommandBase
        where TResultType : new()
    {
        protected readonly IMapper Mapper;
        public CommandCreateHandlerBase(IUnitOfWorkBase unitOfWork, IMapper mapper)
            : base(unitOfWork)
        {
            Mapper = mapper;
        }

        protected virtual bool DoCreate<TEntity, TModel>(ICommandCreateBase<TModel> command)
            where TEntity : DtoBase
        {
            var repository = UnitOfWork.Repository<TEntity>();
            return DoCreate(command, repository);
        }

        protected virtual bool DoCreate<TEntity, TModel>(ICommandCreateBase<TModel> command, IRpstBase<TEntity> repository)
            where TEntity : DtoBase
        {
            TEntity entity;
            try
            {
                entity = Mapper.Map<TEntity>(command.Model);
                repository.Add(Context, entity);
                return true;
            }
            catch
            {
                SericeResult.ErrorMessages.Add(Constants.CommonMessages.AUTO_MAPPING_DOMAIN_TO_DATA_FAILED);
                SericeResult.Success = false;
                return false;
            }
        }
    }
}
