using Tpd.Api.Core.DataAccess;
using Tpd.Api.Core.Service.RequestBases.QueryBases;
using System.Collections;

namespace Tpd.Api.Core.Service.HandlerBases.QueryHandlerBases
{
    public abstract class QueryCollectionAsyncHandlerBase<TQuery, TResultType> : QueryAsyncHandlerBase<TQuery, TResultType>,
        IQueryCollectionHandlerBase<TQuery, TResultType>
        where TQuery : IQueryCollectionBase
        where TResultType : IEnumerable, new()
    {
        public QueryCollectionAsyncHandlerBase(IUnitOfWorkBase unitOfWork)
            : base(unitOfWork)
        {

        }
    }
}
