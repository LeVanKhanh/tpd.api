using Tpd.Api.Core.Service.RequestBases.QueryBases;

namespace Tpd.Api.Core.Service.HandlerBases.QueryHandlerBases
{
    public interface IQuerySingleHandlerBase<TQuery, TResultType> : IQueryHandlerBase<TQuery, TResultType>
        where TQuery : IQuerySingleBase
    {
    }
}
