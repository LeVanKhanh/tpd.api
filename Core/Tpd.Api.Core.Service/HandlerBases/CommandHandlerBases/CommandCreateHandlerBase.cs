using AutoMapper;
using System.Collections.Generic;
using Tpd.Api.Core.DataAccess;
using Tpd.Api.Core.DataTransferObject;
using Tpd.Api.Core.Service.RequestBases.CommandBases;

namespace Tpd.Api.Core.Service.HandlerBases.CommandHandlerBases
{
    //
    // Summary:
    //     An class provide basic functions for handling a command create data.
    public class CommandCreateHandlerBase<TCommand, TEntity, TDto> :
        CommandHandlerBase<TCommand>,
        ICommandCreateHandlerBase<TCommand, TDto>
        where TCommand : ICommandCreateBase<TDto>
        where TEntity : DtoBase
        where TDto : DtoBase
    {
        protected readonly IMapper Mapper;
        public CommandCreateHandlerBase(IUnitOfWorkBase unitOfWork, IMapper mapper)
            : base(unitOfWork)
        {
            Mapper = mapper;
        }
        //
        // Summary:
        //     Tries to build a command to insert an entity into database.
        // Return:
        //     System.Boolean is build command success or not.
        protected override bool TryBuildCommand(TCommand command, RequestContext Context, out List<string> messages)
        {
            messages = new List<string>();
            var repository = UnitOfWork.Repository<TEntity>();
            var entity = CreateEntity(command);
            repository.Add(Context, entity);
            return true;
        }
        //
        // Summary:
        //     Gets data from command then create an entity.
        //     By default, this fuction using auto mapper to create entity.
        //     Derived can override this fuction to implement differnt way to create an entity.
        // Return:
        //     TEntity: Tpd.Api.Core.DataTransferObject.DtoBase an entity will be inserted into data base.
        protected TEntity CreateEntity(TCommand command)
        {
            return Mapper.Map<TEntity>(command.Model);
        }
    }
}
