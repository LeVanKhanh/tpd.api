using Tpd.Api.Core.Service.RequestBases.QueryBases;
using System.Collections;

namespace Tpd.Api.Core.Service.HandlerBases.QueryHandlerBases
{
    public interface IQueryCollectionHandlerBase<in TQuery, TResultType> : IQueryHandlerBase<TQuery, TResultType>
        where TQuery : IQueryCollectionBase
        where TResultType : IEnumerable, new()
    {
        
    }
}
