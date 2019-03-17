using Tpd.Api.Core.DataAccess;
using Tpd.Api.Core.Service.RequestBases.CommandBases;
using Tpd.Api.Core.Service.CommandResultBases;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Tpd.Api.Core.Service.HandlerBases.CommandHandlerBases
{
    public abstract class CommandAsyncHandlerBase<TCommand, TResultType> : ICommandAsyncHandlerBase<TCommand, TResultType>
        where TCommand : ICommandBase
        where TResultType : new()
    {
        protected readonly IUnitOfWorkBase UnitOfWork;
        protected ICommandResultBase<TResultType> SericeResult;
        protected RequestContext Context;

        public CommandAsyncHandlerBase(IUnitOfWorkBase unitOfWork)
        {
            UnitOfWork = unitOfWork;
            SericeResult = new CommandResultBase<TResultType>();
            Context = new RequestContext();
        }

        public virtual async Task<ICommandResultBase<TResultType>> Execute(TCommand command)
        {
            Context = new RequestContext
            {
                TenantId = command.Context.TenantId,
                UserId = command.Context.UserId
            };

            if (IsValidAll(command))
            {
                if (await DoWork(command))
                {
                    Commit();
                }
            }
            else
            {
                SericeResult.ErrorMessages = command.Messages;
            }

            return SericeResult;
        }

        private bool IsValidAll(TCommand command)
        {
            if (!command.IsValid())
            {
                return false;
            }

            return IsValid(command);
        }

        protected virtual void Commit()
        {
            try
            {
                UnitOfWork.Commit();
                SericeResult.Success = true;
            }
            catch (DbUpdateException dbEx)
            {
                SericeResult.Success = false;
                SericeResult.ErrorMessages.Add(dbEx.InnerException.Message);
            }
            catch (Exception ex)
            {
                SericeResult.Success = false;
                SericeResult.ErrorMessages.Add(ex.Message);
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
        }

        protected virtual bool IsValid(TCommand command)
        {
            return true;
        }

        protected abstract Task<bool> DoWork(TCommand command);
    }
}
