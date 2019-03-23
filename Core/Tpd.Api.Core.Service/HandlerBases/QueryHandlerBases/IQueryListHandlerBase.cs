using Tpd.Api.Core.Service.RequestBases.QueryBases;
using Tpd.Api.Core.Service.ResultBases;

namespace Tpd.Api.Core.Service.HandlerBases.QueryHandlerBases
{
    //
    // Summary:
    //     An abstract class provide basic functions for handling a request to get list of items.
    public interface IQueryListHandlerBase<TQuery, TResultType> : IQueryHandlerBase<TQuery, PagedResult<TResultType>>
        where TQuery : IQueryListBase
    {
    }
}
