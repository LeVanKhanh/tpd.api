using Tpd.Api.Core.Service.RequestBases.QueryBases;
using Tpd.Api.Core.Service.HandlerBases.QueryHandlerBases;
using Tpd.Api.Example.DataAccess.UnitOfWork;

namespace Tpd.Api.Example.Service.Handlers.QueryHandlers
{
    public abstract class QueryListHandler<TQuery, TResultType> : QueryListHandlerBase<TQuery, TResultType>
        where TQuery : IQueryListBase
    {
        protected new IUnitOfWork UnitOfWork { get; set; }

        public QueryListHandler(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
    }
}
