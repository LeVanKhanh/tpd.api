using Tpd.Api.Core.DataAccess;
using Tpd.Api.Core.Service.RequestBases.QueryBases;

namespace Tpd.Api.Core.Service.HandlerBases.QueryHandlerBases
{
    public abstract class QueryHandlerBase<TQuery, TResultType> : IQueryHandlerBase<TQuery, TResultType>
        where TQuery : IQueryBase
        where TResultType : new()
    {
        protected readonly IUnitOfWorkBase UnitOfWork;

        public QueryHandlerBase(IUnitOfWorkBase unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        protected bool IsValidAll(TQuery query)
        {
            if (!query.IsValid())
            {
                return false;
            }

            return IsValid(query);
        }

        protected virtual bool IsValid(TQuery query)
        {
            return true;
        }

        protected abstract TResultType DoQuery(TQuery query);
    }
}
