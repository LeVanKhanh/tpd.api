using Tpd.Api.Core.Service.RequestBases.QueryBases;
using Tpd.Api.Core.Service.QueryResultBases;

namespace Tpd.Api.Core.Service.HandlerBases.QueryHandlerBases
{
    public interface IQuerySingleHandlerBase<in TQuery, TResultType> : IQueryHandlerBase<TQuery, TResultType>
        where TQuery : IQuerySingleBase
    {
        IQuerySingleResultBase<TResultType> Query(TQuery query);
    }
}
