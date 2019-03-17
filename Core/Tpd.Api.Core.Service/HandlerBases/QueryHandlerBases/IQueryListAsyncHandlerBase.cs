using Tpd.Api.Core.Service.RequestBases.QueryBases;
using Tpd.Api.Core.Service.QueryResultBases;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tpd.Api.Core.Service.HandlerBases.QueryHandlerBases
{
    public interface IQueryListAsyncHandlerBase<in TQuery, TResultType> : IQueryCollectionHandlerBase<TQuery, List<TResultType>>
        where TQuery : IQueryCollectionBase
    {
        Task<IQueryListResultBase<TResultType>> Query(TQuery query);
    }
}

