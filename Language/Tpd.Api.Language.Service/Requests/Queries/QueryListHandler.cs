using Tpd.Api.Core.Service.HandlerBases.QueryHandlerBases;
using Tpd.Api.Core.Service.RequestBases.QueryBases;
using Tpd.Api.Language.DataAccess.UnitOfWork;

namespace Tpd.Api.Language.Service.Requests.Queries
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
