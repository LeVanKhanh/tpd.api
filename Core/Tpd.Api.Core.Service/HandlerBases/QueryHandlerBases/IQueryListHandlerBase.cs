using Tpd.Api.Core.Service.RequestBases.QueryBases;
using Tpd.Api.Core.Service.ResultBases;

namespace Tpd.Api.Core.Service.HandlerBases.QueryHandlerBases
{
    public interface IQueryListHandlerBase<TQuery, TResultType> : IQueryHandlerBase<TQuery, PagedResult<TResultType>>
        where TQuery : IQueryListBase
    {
    }
}
