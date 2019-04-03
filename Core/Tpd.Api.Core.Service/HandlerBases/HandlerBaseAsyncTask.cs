using System.Threading.Tasks;
using Tpd.Api.Core.DataAccess;
using Tpd.Api.Core.Service.RequestBases;
using Tpd.Api.Core.Service.ResultBases;

namespace Tpd.Api.Core.Service.HandlerBases
{
    public abstract class HandlerBaseAsyncTask<TRequest, TResultType>
        where TRequest : IRequestBase
    {
        protected readonly IUnitOfWorkBase UnitOfWork;

        public HandlerBaseAsyncTask(IUnitOfWorkBase unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
        //
        // Summary:
        //     A function for Handling a request.
        //     Gets request context, checks the request is valid or not, then access or update DB.
        // Parameters:
        //     request: Tpd.Api.Core.Service.RequestBases.IRequestBase the request will be handled.
        public async Task<IResultBase<TResultType>> HandleAsyncTask(TRequest request)
        {
            //Gets request context
            var Context = new RequestContext
            {
                TenantId = request.Context.TenantId,
                UserId = request.Context.UserId
            };

            // Checks the request is valid or not
            if (await IsValidAllAsync(request))
            {
                return await HandleAsync(request, Context);
            }
            else
            {
                return new ResultBase<TResultType>
                {
                    Success = false,
                    ErrorMessages = request.Messages
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
        protected abstract Task<IResultBase<TResultType>> HandleAsync(TRequest request, RequestContext Context);
        //
        // Summary:
        //     The function for request validation and handler validation.
        //     This function is base function for get the result that is the data of request valid or not.
        // Return:
        //     System.Boolean is request valid
        protected async Task<bool> IsValidAllAsync(TRequest request)
        {
            if (request.IsValid())
            {
                return await IsValidAsync(request);
            }
            return false;
        }
        //
        // Summary:
        //     This function for derived class to implement to check the data of request is valid not not.
        //     Use this fuction in case need to read database for checking.
        // Return:
        //     System.Boolean is request valid
        protected virtual async Task<bool> IsValidAsync(TRequest query)
        {
            return true;
        }
    }
}
