using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tpd.Api.Core.DataAccess;
using Tpd.Api.Core.Service.RequestBases.CommandBases;
using Tpd.Api.Core.Service.ResultBases;

namespace Tpd.Api.Core.Service.HandlerBases.CommandHandlerBases
{
    //
    // Summary:
    //     An abstract class provide basic functions for handling a command.
    public abstract class CommandAsyncHandlerBase<TCommand> : HandlerAsyncBase<TCommand, int>,
        ICommandAsyncHandlerBase<TCommand>
        where TCommand : ICommandBase
    {
        public CommandAsyncHandlerBase(IUnitOfWorkBase unitOfWork)
            : base(unitOfWork)
        {

        }
        //
        // Summary:
        //     This function for Handling a command.
        //     Checks is build command(s) success or not then execute the command(s)
        // Return:
        //     Tpd.Api.Core.Service.ResultBases.IResultBase<int>.
        //     With this result can be known the request is handled success or not.
        //     And the result also contain message(s) if gets error(s).
        //     System.Int: The number of state entries written to the database.
        protected async sealed override Task<IResultBase<int>> HandleAsync(TCommand command, RequestContext Context)
        {
            List<string> message;
            if (TryBuildCommand(command, Context, out message))
            {
                int result = await ExecuteAsync();
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
        //
        // Summary:
        //     Saves all changes made in this context to the database.
        // Return:
        //     System.Int: The number of state entries written to the database.
        private async Task<int> ExecuteAsync()
        {
            try
            {
                return await UnitOfWork.CommitAsync();
            }
            catch (DbUpdateException dbEx)
            {
                throw new Exception(dbEx.InnerException.Message);
            }
        }
        //
        // Summary:
        //     Requires derived class to implement this function.
        //     Derived class will implement this function to build command(s).
        // Return:
        //     System.Boolean is build command(s) success or not.
        protected abstract bool TryBuildCommand(TCommand command, RequestContext Context, out List<string> messages);
    }
}
