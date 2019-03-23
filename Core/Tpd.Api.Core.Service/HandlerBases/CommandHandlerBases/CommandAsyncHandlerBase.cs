using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tpd.Api.Core.DataAccess;
using Tpd.Api.Core.Service.RequestBases.CommandBases;
using Tpd.Api.Core.Service.ResultBases;

namespace Tpd.Api.Core.Service.HandlerBases.CommandHandlerBases
{
    public abstract class CommandAsyncHandlerBase<TCommand> : HandlerAsyncBase<TCommand, int>,
        ICommandAsyncHandlerBase<TCommand>
        where TCommand : ICommandBase
    {
        public CommandAsyncHandlerBase(IUnitOfWorkBase unitOfWork)
            : base(unitOfWork)
        {

        }

        protected async sealed override Task<IResultBase<int>> HandleAsync(TCommand command, RequestContext Context)
        {
            List<string> message;
            if (TryBuildCommand(command, Context, out message))
            {
                int result = await CommitAsync();
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
        private async Task<int> CommitAsync()
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

        // Function for implemment bussines before commit change
        protected abstract bool TryBuildCommand(TCommand command, RequestContext Context, out List<string> messages);
    }
}
