using Tpd.Api.Core.DataAccess;
using Tpd.Api.Core.Service.RequestBases.QueryBases;

namespace Tpd.Api.Core.Service.HandlerBases.QueryHandlerBases
{
    public abstract class QueryHandlerBase<TQuery, TResultType> : HandlerBase<TQuery, TResultType>,
        IQueryHandlerBase<TQuery, TResultType>
        where TQuery : IQueryBase
        where TResultType : new()
    {
        public QueryHandlerBase(IUnitOfWorkBase unitOfWork)
            : base(unitOfWork)
        {

        }
    }
}
