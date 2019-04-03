using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Tpd.Api.Core.DataAccess;
using Tpd.Api.Core.Service.RequestBases.QueryBases;
using Tpd.Api.Core.Service.ResultBases;
using Tpd.Api.Utility.Linq;

namespace Tpd.Api.Core.Service.HandlerBases.QueryHandlerBases
{
    public abstract class QueryListHandlerBaseAsync<TQuery, TResultType> : QueryHandlerBaseAsync<TQuery, PagedResult<TResultType>>,
        IQueryListHandlerBaseAsync<TQuery, TResultType>
        where TQuery : IQueryListBase
    {
        public QueryListHandlerBaseAsync(IUnitOfWorkBase unitOfWork)
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
        protected sealed async override Task<IResultBase<PagedResult<TResultType>>> HandleAsync(TQuery query, RequestContext context)
        {
            var result = new ResultBase<PagedResult<TResultType>>
            {
                Success = true,
                Result = new PagedResult<TResultType>()
            };

            var queryable = await BuildQueryAsync(query, context);

            if (queryable == null)
            {
                result.Success = false;
                result.ErrorMessages = query.Messages;
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
            result.Result.Items = await queryable.ToListAsync();

            return result;
        }
        //
        // Summary:
        //     Requires derived class to implement this function.
        //     Derived class will implement this function to build query.
        // Return:
        //     System.Boolean is build query success or not.
        protected abstract Task<IQueryable<TResultType>> BuildQueryAsync(TQuery query, RequestContext context);
    }
}
