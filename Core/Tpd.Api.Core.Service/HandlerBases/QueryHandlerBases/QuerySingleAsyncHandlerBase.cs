using Tpd.Api.Core.DataAccess;
using Tpd.Api.Core.Service.RequestBases.QueryBases;
using Tpd.Api.Core.Service.QueryResultBases;
using System.Threading.Tasks;

namespace Tpd.Api.Core.Service.HandlerBases.QueryHandlerBases
{
    public abstract class QuerySingleAsyncHandlerBase<TQuery, TResultType> : QueryAsyncHandlerBase<TQuery, TResultType>,
        IQuerySingleAsyncHandlerBase<TQuery, TResultType>
        where TQuery : IQuerySingleBase
        where TResultType : new()
    {
        protected IQuerySingleResultBase<TResultType> SingleResult;

        public QuerySingleAsyncHandlerBase(IUnitOfWorkBase unitOfWork)
            : base(unitOfWork)
        {
            SingleResult = new QuerySingleResultBase<TResultType>();
        }

        public virtual async Task<IQuerySingleResultBase<TResultType>> Query(TQuery query)
        {
            if (IsValidAll(query))
            {
                SingleResult.Result = await DoQuery(query);
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
