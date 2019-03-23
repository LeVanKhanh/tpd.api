using System.Collections.Generic;
using System.Threading.Tasks;
using Tpd.Api.Core.DataAccess;
using Tpd.Api.Core.Service.RequestBases;
using Tpd.Api.Core.Service.ResultBases;

namespace Tpd.Api.Core.Service.HandlerBases
{
    public abstract class HandlerAsyncBase<TRequest, TResultType>
        where TRequest : IRequestBase
    {
        protected readonly IUnitOfWorkBase UnitOfWork;

        public HandlerAsyncBase(IUnitOfWorkBase unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

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

        protected abstract Task<IResultBase<TResultType>> HandleAsync(TRequest command, RequestContext Context);

        protected bool IsValidAll(TRequest request, out List<string> message)
        {
            if (!request.IsValid())
            {
                message = request.Messages;
                return false;
            }

            return IsValid(request, out message);
        }

        protected virtual bool IsValid(TRequest query, out List<string> message)
        {
            message = new List<string> { };
            return true;
        }
    }
}
