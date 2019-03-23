using System.Collections.Generic;
using System.Linq;
using Tpd.Api.Core.DataAccess;
using Tpd.Api.Core.Service.RequestBases.QueryBases;
using Tpd.Api.Core.Service.ResultBases;

namespace Tpd.Api.Core.Service.HandlerBases.QueryHandlerBases
{
    public abstract class QuerySingleHandlerBase<TQuery, TResultType> : QueryHandlerBase<TQuery, TResultType>,
        IQuerySingleHandlerBase<TQuery, TResultType>
        where TQuery : IQuerySingleBase
        where TResultType : new()
    {
        public QuerySingleHandlerBase(IUnitOfWorkBase unitOfWork)
            : base(unitOfWork)
        {

        }

        protected override IResultBase<TResultType> Handle(TQuery query, RequestContext context)
        {
            var result = new ResultBase<TResultType>
            {
                Success = true
            };

            IQueryable<TResultType> queryable;
            List<string> message;

            if (!TryBuildQuery(query, context, out queryable, out message))
            {
                result.Success = false;
                result.ErrorMessages = message;
                return result;
            }

            result.Result = queryable.FirstOrDefault();

            return result;
        }

        protected abstract bool TryBuildQuery(TQuery query, RequestContext context, out IQueryable<TResultType> queryable, out List<string> message);
    }
}
