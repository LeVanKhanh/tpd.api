using System.Threading.Tasks;
using Tpd.Api.Core.DataAccess;
using Tpd.Api.Core.Service.RequestBases.CommandBases;

namespace Tpd.Api.Core.Service.HandlerBases.CommandHandlerBases
{
    //
    // Summary:
    //     An abstract class provide basic functions for handling a command.
    //     This class provide Async function to optimize process.
    //     This class no need to return result, just excecute the command.
    //     TODO: implement log to track every step of handling the command.
    public abstract class CommandHandlerBaseAsyncVoid<TCommand> : ICommandHandlerBaseAsyncVoid<TCommand>
        where TCommand : ICommandBase
    {
        protected readonly IUnitOfWorkBase UnitOfWork;

        public CommandHandlerBaseAsyncVoid(IUnitOfWorkBase unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
        //
        // Summary:
        //     A function for Handling a request.
        //     Gets command context, checks the command is valid or not then .
        public async void HandleAsyncVoid(TCommand command)
        {
            //Gets request context
            var Context = new RequestContext
            {
                TenantId = command.Context.TenantId,
                UserId = command.Context.UserId
            };

            // Checks the request is valid or not
            if (await IsValidAllAsync(command))
            {
                HandleAsync(command, Context);
            }
        }
        //
        // Summary:
        //     Requires derived class to implement this function.
        //     This function is the special handle a quest.
        protected abstract void HandleAsync(TCommand command, RequestContext Context);
        //
        // Summary:
        //     The function for request validation and handler validation.
        //     This function is base function for get the result that is the data of request valid or not.
        // Return:
        //     System.Boolean is request valid
        protected async Task<bool> IsValidAllAsync(TCommand command)
        {
            if (command.IsValid())
            {
                return await IsValidAsync(command);
            }
            return false;
        }
        //
        // Summary:
        //     This function for derived class to implement to check the data of request is valid not not.
        //     Use this fuction in case need to read database for checking.
        // Return:
        //     System.Boolean is request valid
        protected virtual async Task<bool> IsValidAsync(TCommand command)
        {
            return true;
        }
    }
}
