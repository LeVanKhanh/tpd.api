using System.Collections.Generic;
using System.Linq;
using Tpd.Api.Core.DataAccess;
using Tpd.Api.Core.Service.RequestBases.QueryBases;
using Tpd.Api.Core.Service.ResultBases;
using Tpd.Api.Utility.Linq;

namespace Tpd.Api.Core.Service.HandlerBases.QueryHandlerBases
{
    //
    // Summary:
    //     An abstract class provide basic functions for handling a request to get list of items.
    public abstract class QueryListHandlerBase<TQuery, TResultType> : QueryHandlerBase<TQuery, PagedResult<TResultType>>,
        IQueryListHandlerBase<TQuery, TResultType>
        where TQuery : IQueryListBase
    {
        public QueryListHandlerBase(IUnitOfWorkBase unitOfWork)
            : base(unitOfWork)
        {
        }
        //
        // Summary:
        //     This function for Handling a request to get list of items.
        //     Checks is build command(s) success or not then execute the command(s)
        // Return:
        //     Tpd.Api.Core.Service.ResultBases.IResultBase<PagedResult<TResultType>>.
        //     With this result can be known the request is handled success or not.
        //     And the result also contain message(s) if gets error(s).
        //     TResultType: type of item will be get list.
        //     Tpd.Api.Core.Service.ResultBases.PagedResult<T> will provide information about the list as list items, 
        //     total items.
        protected sealed override IResultBase<PagedResult<TResultType>> Handle(TQuery query, RequestContext context)
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
        //
        // Summary:
        //     Requires derived class to implement this function.
        //     Derived class will implement this function to build query.
        // Return:
        //     System.Boolean is build query success or not.
        protected abstract bool TryBuildQuery(TQuery query, out IQueryable<TResultType> queryable, out List<string> message);
    }
}
