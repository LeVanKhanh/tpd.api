﻿using System.Linq;
using Tpd.Api.Core.DataAccess;
using Tpd.Api.Core.Service.RequestBases.QueryBases;
using Tpd.Api.Core.Service.ResultBases;

namespace Tpd.Api.Core.Service.HandlerBases.QueryHandlerBases
{
    //
    // Summary:
    //     An abstract class provide basic functions for handling a request to get one item.
    public abstract class QuerySingleHandlerBase<TQuery, TResultType> : QueryHandlerBase<TQuery, TResultType>,
        IQuerySingleHandlerBase<TQuery, TResultType>
        where TQuery : IQuerySingleBase
        where TResultType : new()
    {
        public QuerySingleHandlerBase(IUnitOfWorkBase unitOfWork)
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
        //     TResultType: type of item will be get.
        protected sealed override IResultBase<TResultType> Handle(TQuery query, RequestContext context)
        {
            var result = new ResultBase<TResultType>
            {
                Success = true
            };

            var queryable= BuildQuery(query, context);

            if (queryable == null)
            {
                result.Success = false;
                result.ErrorMessages = query.Messages;
                return result;
            }

            result.Result = queryable.FirstOrDefault();

            return result;
        }
        //
        // Summary:
        //     Requires derived class to implement this function.
        //     Derived class will implement this function to build query.
        // Return:
        //     System.Boolean is build query success or not.
        protected abstract IQueryable<TResultType> BuildQuery(TQuery query, RequestContext context);
    }
}
