using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Tpd.Api.Core.DataAccess;
using Tpd.Api.Core.Service.RequestBases.CommandBases;
using Tpd.Api.Core.Service.ResultBases;

namespace Tpd.Api.Core.Service.HandlerBases.CommandHandlerBases
{
    /// <summary>
    /// The class for executing a command
    /// </summary>
    /// <typeparam name="TCommand">Type Of Command Object</typeparam>
    public abstract class CommandHandlerBase<TCommand> : HandlerBase<TCommand, int>,
        ICommandHandlerBase<TCommand>
        where TCommand : ICommandBase
    {
        public CommandHandlerBase(IUnitOfWorkBase unitOfWork)
            : base(unitOfWork)
        {

        }

        protected sealed override IResultBase<int> Handle(TCommand command, RequestContext Context)
        {
            List<string> message;
            if (TryBuildCommand(command, Context, out message))
            {
                int result = Commit();
                return new ResultBase<int>
                {
                    Success = true,
                    Result = result
                };
            }
            else
            {
                return new ResultBase<int>
                {
                    Success = true,
                    ErrorMessages = message
                };
            }
        }

        /// <summary>
        /// Function for try commit change(s)
        /// </summary>
        private int Commit()
        {
            try
            {
                return UnitOfWork.Commit();
            }
            catch (DbUpdateException dbEx)
            {
                throw new Exception(dbEx.InnerException.Message);
            }
        }

        // Function for implemment bussines before commit change
        protected abstract bool TryBuildCommand(TCommand command, RequestContext Context, out List<string> messages);
    }
}
