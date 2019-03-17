using Tpd.Api.Core.DataAccess;
using Tpd.Api.Core.Service.RequestBases.QueryBases;
using Tpd.Api.Core.Service.QueryResultBases;
using Tpd.Api.Utility.Linq;
using System.Collections.Generic;
using System.Linq;

namespace Tpd.Api.Core.Service.HandlerBases.QueryHandlerBases
{
    public abstract class QueryListHandlerBase<TQuery, TResultType> : QueryCollectionHandlerBase<TQuery, List<TResultType>>,
        IQueryListHandlerBase<TQuery, TResultType>
        where TQuery : IQueryListBase
    {
        protected IQueryListResultBase<TResultType> CollectionResult;

        public QueryListHandlerBase(IUnitOfWorkBase unitOfWork)
            : base(unitOfWork)
        {
            CollectionResult = new QueryListResultBase<TResultType>();
        }

        public virtual IQueryListResultBase<TResultType> Query(TQuery query)
        {
            if (IsValidAll(query))
            {
                CollectionResult.Result = DoQuery(query);
            }
            else
            {
                CollectionResult.ErrorMessages = query.Messages;
            }

            return CollectionResult;
        }

        protected abstract IQueryable<TResultType> BuildQuery(TQuery query);

        protected override List<TResultType> DoQuery(TQuery query)
        {
            var dataQuery = BuildQuery(query);

            CollectionResult.TotalRow = dataQuery.Count();

            if(!string.IsNullOrEmpty(query.OrderBy))
            {
                dataQuery = dataQuery.OrderBy(query.OrderBy, query.OrderByDirection);
            }

            if (query.IsPaged)
            {
                dataQuery = dataQuery.Skip(query.Skip).Take(query.Take);
            }

            CollectionResult.Success = true;
            return dataQuery.ToList();
        }
    }
}
