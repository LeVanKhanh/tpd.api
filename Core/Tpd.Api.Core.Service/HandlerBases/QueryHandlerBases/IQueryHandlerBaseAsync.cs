using System.Threading.Tasks;
using Tpd.Api.Core.Service.RequestBases.QueryBases;
using Tpd.Api.Core.Service.ResultBases;

namespace Tpd.Api.Core.Service.HandlerBases.QueryHandlerBases
{
    public interface IQueryHandlerBaseAsync<TQuery, TResultType>
        where TQuery : IQueryBase
    {
        Task<IResultBase<TResultType>> HandleAsyncTask(TQuery query);
    }
}
