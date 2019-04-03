using Tpd.Api.Core.DataAccess;
using Tpd.Api.Core.Service.RequestBases.QueryBases;

namespace Tpd.Api.Core.Service.HandlerBases.QueryHandlerBases
{
    public abstract class QueryHandlerBaseAsync<TQuery, TResultType>: HandlerBaseAsyncTask<TQuery, TResultType>,
        IQueryHandlerBaseAsync<TQuery, TResultType>
        where TQuery : IQueryBase
        where TResultType : new()
    {
        public QueryHandlerBaseAsync(IUnitOfWorkBase unitOfWork)
           : base(unitOfWork)
        {

        }
    }
}
