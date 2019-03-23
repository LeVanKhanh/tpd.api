using System.Collections.Generic;
using System.Linq;
using Tpd.Api.Core.DataAccess;
using Tpd.Api.Core.Service.RequestBases.QueryBases;
using Tpd.Api.Core.Service.ResultBases;
using Tpd.Api.Utility.Linq;

namespace Tpd.Api.Core.Service.HandlerBases.QueryHandlerBases
{
    public abstract class QueryListHandlerBase<TQuery, TResultType> : QueryHandlerBase<TQuery, PagedResult<TResultType>>,
        IQueryListHandlerBase<TQuery, TResultType>
        where TQuery : IQueryListBase
    {
        public QueryListHandlerBase(IUnitOfWorkBase unitOfWork)
            : base(unitOfWork)
        {
        }

        protected override IResultBase<PagedResult<TResultType>> Handle(TQuery query, RequestContext context)
        {
            var result = new ResultBase<PagedResult<TResultType>>
            {
                Success = true
            };

            IQueryable<TResultType> queryable;
            List<string> message;

            if (!TryBuildQuery(query, out queryable, out message))
            {
                result.Success = false;
                result.ErrorMessages = message;
                return result;
            }

            result.Result.TotalRow = queryable.Count();

            if (!string.IsNullOrEmpty(query.OrderBy))
            {
                queryable = queryable.OrderBy(query.OrderBy, query.OrderByDirection);
            }

            if (query.IsPaged)
            {
                result.Result.Skip = query.Skip;
                result.Result.Take = query.Take;
                queryable = queryable.Skip(query.Skip).Take(query.Take);
            }

            result.Success = true;
            result.Result.Items = queryable.ToList();

            return result;
        }

        protected abstract bool TryBuildQuery(TQuery query, out IQueryable<TResultType> queryable, out List<string> message);
    }
}
