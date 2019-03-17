using Tpd.Api.Core.Service.RequestBases.QueryBases;
using Tpd.Api.Core.Service.QueryResultBases;
using System.Collections.Generic;

namespace Tpd.Api.Core.Service.HandlerBases.QueryHandlerBases
{
    public interface IQueryListHandlerBase<in TQuery, TResultType> : IQueryCollectionHandlerBase<TQuery, List<TResultType>>
        where TQuery : IQueryCollectionBase
    {
        IQueryListResultBase<TResultType> Query(TQuery query);
    }
}
