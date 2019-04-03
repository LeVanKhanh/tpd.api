using Tpd.Api.Core.Service.HandlerBases.QueryHandlerBases;
using Tpd.Api.Core.Service.RequestBases.QueryBases;
using Tpd.Api.Example.DataAccess.UnitOfWork;

namespace Tpd.Api.Example.Service.Handlers.QueryHandlers
{
    public abstract class QuerySingleHandlerAsync<TQuery, TResultType> : QuerySingleHandlerBaseAsync<TQuery, TResultType>
        where TQuery : IQuerySingleBase
        where TResultType : new()
    {
        protected new IUnitOfWork UnitOfWork { get; set; }
        public QuerySingleHandlerAsync(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
    }
}
