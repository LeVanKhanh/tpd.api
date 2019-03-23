using System.Collections.Generic;
using System.Threading.Tasks;
using Tpd.Api.Core.DataAccess;
using Tpd.Api.Core.Service.RequestBases;
using Tpd.Api.Core.Service.ResultBases;

namespace Tpd.Api.Core.Service.HandlerBases
{
    //
    // Summary:
    //     An abstract class provide basic functions for handling a request.
    public abstract class HandlerAsyncBase<TRequest, TResultType>
        where TRequest : IRequestBase
    {
        protected readonly IUnitOfWorkBase UnitOfWork;

        public HandlerAsyncBase(IUnitOfWorkBase unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
        //
        // Summary:
        //     This function for Handling a request.
        //     Gets request context, checks the request is valid or not, then access or update DB.
        // Parameters:
        //     request: Tpd.Api.Core.Service.RequestBases.IRequestBase the request will be handled.
        public async Task<IResultBase<TResultType>> HandleAsync(TRequest request)
        {
            var Context = new RequestContext
            {
                TenantId = request.Context.TenantId,
                UserId = request.Context.UserId
            };

            List<string> messages;

            if (IsValidAll(request, out messages))
            {
                return await HandleAsync(request, Context);
            }
            else
            {
                return new ResultBase<TResultType>
                {
                    Success = false,
                    ErrorMessages = messages
                };
            }
        }
        //
        // Summary:
        //     Requires derived class to implement this function.
        //     This function is the special handle a quest.
        // Return:
        //     Tpd.Api.Core.Service.ResultBases.IResultBase<T>.
        //     With this result can be known the request is handled success or not.
        //     And the result also contain message(s) if gets error(s).
        //     TResultType: Type of and object that the request require to response.
        protected abstract Task<IResultBase<TResultType>> HandleAsync(TRequest command, RequestContext Context);
        //
        // Summary:
        //     The function for request validation and handler validation.
        //     This function is base function for get the result that is the data of request valid or not.
        // Return:
        //     System.Boolean is request valid
        protected bool IsValidAll(TRequest request, out List<string> message)
        {
            if (!request.IsValid())
            {
                message = request.Messages;
                return false;
            }

            return IsValid(request, out message);
        }
        //
        // Summary:
        //     This function for derived class to implement to check the data of request is valid not not.
        //     Use this fuction in case need to read database for checking.
        // Return:
        //     System.Boolean is request valid
        protected virtual bool IsValid(TRequest query, out List<string> message)
        {
            message = new List<string> { };
            return true;
        }
    }
}
