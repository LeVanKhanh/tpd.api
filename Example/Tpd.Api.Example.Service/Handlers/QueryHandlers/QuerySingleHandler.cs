using Tpd.Api.Core.Service.RequestBases.QueryBases;
using Tpd.Api.Core.Service.HandlerBases.QueryHandlerBases;
using Tpd.Api.Example.DataAccess.UnitOfWork;

namespace Tpd.Api.Example.Service.Handlers.QueryHandlers
{
    public abstract class QuerySingleHandler<TQuery, TResultType> : QuerySingleHandlerBase<TQuery, TResultType>
        where TQuery : IQuerySingleBase
        where TResultType : new()
    {
        protected new IUnitOfWork UnitOfWork { get; set; }
        public QuerySingleHandler(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
    }
}
