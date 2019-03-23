using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tpd.Api.Core.Service.HandlerBases.CommandHandlerBases;
using Tpd.Api.Core.Service.HandlerBases.QueryHandlerBases;
using Tpd.Api.Core.Service.RequestBases.CommandBases;
using Tpd.Api.Core.Service.RequestBases.QueryBases;

namespace Tpd.Api.Core.Interface.ControllerBases
{
    /// <summary>
    /// The Abstract controller provide base methods to call services
    /// </summary>
    public abstract class CoreBaseController : ControllerBase
    {
        protected static ResponseModelBase SERVICE_NOT_FOUND { get; private set; }

        public CoreBaseController()
        {
            if (SERVICE_NOT_FOUND == null)
            {
                SERVICE_NOT_FOUND = new ResponseModelBase
                {
                    Success = false,
                    Message = new List<string>
                    {
                        "Service not found"
                    }
                };
            }
        }

        /// <summary>
        /// Call Command Handler
        /// </summary>
        /// <typeparam name="TCommand">Type of Command Object</typeparam>
        /// <param name="command">Command Object</param>
        /// <returns>
        /// Response Model contain service result model 
        /// </returns>
        protected ResponseModelBase DoCommand<TCommand>(TCommand command)
            where TCommand : ICommandBase
        {
            //Get command handler
            var handler = HttpContext.RequestServices.GetService<ICommandHandlerBase<TCommand>>();

            if (handler == null)
            {
                return SERVICE_NOT_FOUND;
            }

            //Execute command
            var handlerResult = handler.Handle(command);

            //The command handler return null
            if (handlerResult == null)
            {
                return SERVICE_NOT_FOUND;
            }

            //Got handled error(s)
            if (!handlerResult.Success)
            {
                return new ResponseModelBase
                {
                    Success = false,
                    Message = handlerResult.ErrorMessages
                };
            }

            //Command was executed succeed
            return new ResponseModelBase
            {
                Success = true,
                Count = 1,
                Data = handlerResult.Result
            };
        }

        /// <summary>
        /// Call Query Item Handler
        /// </summary>
        /// <typeparam name="TQuery">Type of Query Single Object.</typeparam>
        /// <typeparam name="TQuerySingleResult">Type of Handler Result Object</typeparam>
        /// <param name="query">Query Single Object</param>
        /// <returns>
        /// Response Model contain service result model.
        /// The service result is not Collection Object.
        /// </returns>
        protected ResponseModelBase DoQueryItem<TQuery, TQuerySingleResult>(TQuery query)
            where TQuery : IQuerySingleBase
        {
            //Get query handler
            var handler = HttpContext.RequestServices.GetService<IQuerySingleHandlerBase<TQuery, TQuerySingleResult>>();

            if (handler == null)
            {
                return SERVICE_NOT_FOUND;
            }

            //Query Data
            var handlerResult = handler.Handle(query);

            //If query handler return null
            if (handlerResult == null)
            {
                return SERVICE_NOT_FOUND;
            }

            //Got handled error(s)
            if (!handlerResult.Success)
            {
                return new ResponseModelBase
                {
                    Success = false,
                    Message = handlerResult.ErrorMessages
                };
            }

            //Queried succeed
            return new ResponseModelBase
            {
                Success = true,
                Count = 1,
                Data = handlerResult.Result
            };
        }

        /// <summary>
        /// Call Query List Handler
        /// </summary>
        /// <typeparam name="TQuery">Type of Query List Object</typeparam>
        /// <typeparam name="TQueryListResult">Type Handler of Result Object</typeparam>
        /// <param name="query">Query List Object</param>
        /// <returns>
        /// Response Model contain service result model.
        /// The service result is List.
        /// </returns>
        protected ResponseModelBase DoQueryList<TQuery, TQueryListResult>(TQuery query)
            where TQuery : IQueryListBase
        {
            //Get query handler
            var handler = HttpContext.RequestServices.GetService<IQueryListHandlerBase<TQuery, TQueryListResult>>();

            if (handler == null)
            {
                return SERVICE_NOT_FOUND;
            }

            //Query Data
            var handlerResult = handler.Handle(query);

            //If query handler return null
            if (handlerResult == null)
            {
                return SERVICE_NOT_FOUND;
            }

            //Got handled error(s)
            if (!handlerResult.Success)
            {
                return new ResponseModelBase
                {
                    Success = false,
                    Message = handlerResult.ErrorMessages
                };
            }

            //Queried succeed
            return new ResponseModelBase
            {
                Success = true,
                Count = handlerResult.Result.TotalRow,
                Data = handlerResult.Result
            };
        }

        /// <summary>
        /// Call Async Command Handler
        /// </summary>
        /// <typeparam name="TCommand">Type of Command Object</typeparam>
        /// <param name="command">Command Object</param>
        /// <returns>
        /// Response Model contain service result model 
        /// </returns>
        protected async Task<ResponseModelBase> DoCommandAsync<TCommand>(TCommand command)
            where TCommand : ICommandBase
        {
            //Get command handler
            var handler = HttpContext.RequestServices.GetService<ICommandAsyncHandlerBase<TCommand>>();

            if (handler == null)
            {
                return SERVICE_NOT_FOUND;
            }

            //Execute command
            var handlerResult = await handler.HandleAsync(command);

            //The command handler return null
            if (handlerResult == null)
            {
                return SERVICE_NOT_FOUND;
            }

            //Got handled error(s)
            if (!handlerResult.Success)
            {
                return new ResponseModelBase
                {
                    Success = false,
                    Message = handlerResult.ErrorMessages
                };
            }

            //Command was executed succeed
            return new ResponseModelBase
            {
                Success = true,
                Count = 1,
                Data = handlerResult.Result
            };
        }

        /// <summary>
        /// Call Async Query Item Handler
        /// </summary>
        /// <typeparam name="TQuery">Type of Query Single Object.</typeparam>
        /// <typeparam name="TQuerySingleResult">Type of Handler Result Object</typeparam>
        /// <param name="query">Query Single Object</param>
        /// <returns>
        /// Response Model contain service result model.
        /// The service result is not Collection Object.
        /// </returns>
        //protected async Task<ResponseModelBase> DoQueryItemAsync<TQuery, TQuerySingleResult>(TQuery query)
        //    where TQuery : IQuerySingleBase
        //{
        //    //Get query handler
        //    var handler = HttpContext.RequestServices.GetService<IQuerySingleAsyncHandlerBase<TQuery, TQuerySingleResult>>();

        //    if (handler == null)
        //    {
        //        return SERVICE_NOT_FOUND;
        //    }

        //    //Query Data
        //    var handlerResult = await handler.Query(query);

        //    //If query handler return null
        //    if (handlerResult == null)
        //    {
        //        return SERVICE_NOT_FOUND;
        //    }

        //    //Got handled error(s)
        //    if (!handlerResult.Success)
        //    {
        //        return new ResponseModelBase
        //        {
        //            Success = false,
        //            Message = handlerResult.ErrorMessages
        //        };
        //    }

        //    //Queried succeed
        //    return new ResponseModelBase
        //    {
        //        Success = true,
        //        Count = 1,
        //        Data = handlerResult.Result
        //    };
        //}

        /// <summary>
        /// Call Async Query List Handler
        /// </summary>
        /// <typeparam name="TQuery">Type of Query List Object</typeparam>
        /// <typeparam name="TQueryListResult">Type of Handler Result Object</typeparam>
        /// <param name="query">Query List Object</param>
        /// <returns>
        /// Response Model contain service result model.
        /// The service result is List.
        /// </returns>
        //protected async Task<ResponseModelBase> DoQueryListAsync<TQuery, TQueryListResult>(TQuery query)
        //    where TQuery : IQueryListBase
        //{
        //    //Get query handler
        //    var handler = HttpContext.RequestServices.GetService<IQueryListAsyncHandlerBase<TQuery, TQueryListResult>>();

        //    if (handler == null)
        //    {
        //        return SERVICE_NOT_FOUND;
        //    }

        //    //Query Data
        //    var handlerResult = await handler.QueryAsync(query);

        //    //If query handler return null
        //    if (handlerResult == null)
        //    {
        //        return SERVICE_NOT_FOUND;
        //    }

        //    //Got handled error(s)
        //    if (!handlerResult.Success)
        //    {
        //        return new ResponseModelBase
        //        {
        //            Success = false,
        //            Message = handlerResult.ErrorMessages
        //        };
        //    }

        //    //Queried succeed
        //    return new ResponseModelBase
        //    {
        //        Success = true,
        //        Count = handlerResult.TotalRow,
        //        Data = handlerResult.Result
        //    };
        //}

    }
}
