using Tpd.Api.Core.Service.RequestBases.QueryBases;
using Tpd.Api.Core.Service.QueryResultBases;
using System.Threading.Tasks;

namespace Tpd.Api.Core.Service.HandlerBases.QueryHandlerBases
{
    public interface IQuerySingleAsyncHandlerBase<in TQuery, TResultType> : IQueryHandlerBase<TQuery, TResultType>
        where TQuery : IQuerySingleBase
    {
        Task<IQuerySingleResultBase<TResultType>> Query(TQuery query);
    }
}
