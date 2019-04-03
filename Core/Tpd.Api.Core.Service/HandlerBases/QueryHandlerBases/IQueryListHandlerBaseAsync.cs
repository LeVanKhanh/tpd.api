using Tpd.Api.Core.Service.RequestBases.QueryBases;
using Tpd.Api.Core.Service.ResultBases;

namespace Tpd.Api.Core.Service.HandlerBases.QueryHandlerBases
{
    public interface IQueryListHandlerBaseAsync<TQuery, TResultType> : IQueryHandlerBaseAsync<TQuery, PagedResult<TResultType>>
        where TQuery : IQueryListBase
    {

    }
}
