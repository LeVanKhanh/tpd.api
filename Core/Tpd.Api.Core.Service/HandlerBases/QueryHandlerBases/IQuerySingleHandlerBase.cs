using Tpd.Api.Core.Service.RequestBases.QueryBases;

namespace Tpd.Api.Core.Service.HandlerBases.QueryHandlerBases
{
    //
    // Summary:
    //     An abstract class provide basic functions for handling a request to get one item.
    public interface IQuerySingleHandlerBase<TQuery, TResultType> : IQueryHandlerBase<TQuery, TResultType>
        where TQuery : IQuerySingleBase
    {
    }
}
