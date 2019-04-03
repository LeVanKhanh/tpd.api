using Tpd.Api.Core.Service.RequestBases.QueryBases;

namespace Tpd.Api.Core.Service.HandlerBases.QueryHandlerBases
{
    public interface IQuerySingleHandlerBaseAsync<TQuery, TResultType> : IQueryHandlerBaseAsync<TQuery, TResultType>
        where TQuery : IQuerySingleBase
    {

    }
}
