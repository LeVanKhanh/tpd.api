using System.Collections.Generic;
using Tpd.Api.Core.DataAccess;
using Tpd.Api.Core.Service.RequestBases;
using Tpd.Api.Core.Service.ResultBases;

namespace Tpd.Api.Core.Service.HandlerBases
{
    public abstract class HandlerBase<TRequest, TResultType>
        where TRequest: IRequestBase
    {
        protected readonly IUnitOfWorkBase UnitOfWork;

        public HandlerBase(IUnitOfWorkBase unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public IResultBase<TResultType> Handle(TRequest request)
        {
            var Context = new RequestContext
            {
                TenantId = request.Context.TenantId,
                UserId = request.Context.UserId
            };

            List<string> messages;

            if (IsValidAll(request, out messages))
            {
                return Handle(request, Context);
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

        protected abstract IResultBase<TResultType> Handle(TRequest command, RequestContext Context);

        /// <summary>
        /// The function for check command validation and handler validation
        /// </summary>
        /// <param name="request"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        protected bool IsValidAll(TRequest request, out List<string> message)
        {
            if (!request.IsValid())
            {
                message = request.Messages;
                return false;
            }

            return IsValid(request, out message);
        }

        /// <summary>
        /// Function for logic validation
        /// </summary>
        /// <param name="query"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        protected virtual bool IsValid(TRequest query, out List<string> message)
        {
            message = new List<string> { };
            return true;
        }
    }
}
