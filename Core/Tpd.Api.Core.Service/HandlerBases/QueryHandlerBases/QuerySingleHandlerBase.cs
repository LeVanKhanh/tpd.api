using Tpd.Api.Core.DataAccess;
using Tpd.Api.Core.Service.RequestBases.QueryBases;
using Tpd.Api.Core.Service.QueryResultBases;

namespace Tpd.Api.Core.Service.HandlerBases.QueryHandlerBases
{
    public abstract class QuerySingleHandlerBase<TQuery, TResultType> : QueryHandlerBase<TQuery, TResultType>,
        IQuerySingleHandlerBase<TQuery, TResultType>
        where TQuery : IQuerySingleBase
        where TResultType : new()
    {
        protected IQuerySingleResultBase<TResultType> SingleResult;

        public QuerySingleHandlerBase(IUnitOfWorkBase unitOfWork)
            : base(unitOfWork)
        {
            SingleResult = new QuerySingleResultBase<TResultType>();
        }

        public virtual IQuerySingleResultBase<TResultType> Query(TQuery query)
        {
            if (IsValidAll(query))
            {
                SingleResult.Result = DoQuery(query);
                SingleResult.Success = true;
            }
            else
            {
                SingleResult.ErrorMessages = query.Messages;
            }

            return SingleResult;
        }
    }
}
