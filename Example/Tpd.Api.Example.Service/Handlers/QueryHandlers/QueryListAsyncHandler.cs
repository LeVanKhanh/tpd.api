using Tpd.Api.Core.Service.RequestBases.QueryBases;
using Tpd.Api.Core.Service.HandlerBases.QueryHandlerBases;
using Tpd.Api.Example.DataAccess.UnitOfWork;

namespace Tpd.Api.Example.Service.Handlers.QueryHandlers
{
    public abstract class QueryListAsyncHandler<TQuery, TResultType> : QueryListAsyncHandlerBase<TQuery, TResultType>
        where TQuery : IQueryListBase
    {
        protected new IUnitOfWork UnitOfWork { get; set; }

        public QueryListAsyncHandler(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
    }
}

