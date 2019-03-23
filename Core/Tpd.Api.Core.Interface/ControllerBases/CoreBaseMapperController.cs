using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Threading.Tasks;
using Tpd.Api.Core.Service.HandlerBases.QueryHandlerBases;
using Tpd.Api.Core.Service.RequestBases.CommandBases;
using Tpd.Api.Core.Service.RequestBases.QueryBases;

namespace Tpd.Api.Core.Interface.ControllerBases
{
    /// <summary>
    /// The Abstract controller provide base methods to call services with automapper
    /// </summary>
    public abstract class CoreBaseMapperController: CoreBaseController
    {
        protected readonly IMapper Mapper;

        public CoreBaseMapperController(IMapper mapper)
        {
            Mapper = mapper;
        }

        /// <summary>
        /// Call Command Handler
        /// </summary>
        /// <typeparam name="TModel">Type of Request Object</typeparam>
        /// <typeparam name="TCommand">Type of Command Object</typeparam>
        /// <typeparam name="TResult">Type of Handler Result Object</typeparam>
        /// <param name="request">Request Object</param>
        /// <returns>
        /// Response Model contain service result model 
        /// </returns>
        protected ActionResult<ResponseModelBase> DoCommand<TModel, TCommand>(RequestModelBase<TModel> request)
           where TCommand : ICommandBase
        {
            //Map data from Request Object to Command Object
            TCommand command = Mapper.Map<TCommand>(request);
            // Call Command Handler
            return DoCommand(command);
        }

        /// <summary>
        /// Call Query Item Handler
        /// </summary>
        /// <typeparam name="TQuery">Type of Query Object</typeparam>
        /// <typeparam name="TQuerySingleResult">Type of Handler Result Object</typeparam>
        /// <typeparam name="TViewModelResult">Type of View Model</typeparam>
        /// <param name="query">Query Object</param>
        /// <returns>
        /// Response Model contain service result model.
        /// The service result is not Collection Object.
        /// </returns>
        protected ResponseModelBase DoQueryItem<TQuery, TQuerySingleResult, TViewModelResult>(TQuery query)
            where TQuery : IQuerySingleBase
        {
            //Call Query Handler
            var queryResult = DoQueryItem<TQuery, TQuerySingleResult>(query);

            if (!queryResult.Success)
            {
                return queryResult;
            }

            //Map data result to view model
            var dataResult = Mapper.Map<TViewModelResult>(queryResult.Data);

            //Queried succeed
            return new ResponseModelBase
            {
                Success = true,
                Count = 1,
                Data = dataResult
            };
        }

        /// <summary>
        /// Call Query List Handler
        /// </summary>
        /// <typeparam name="TQuery">Type of Query Object</typeparam>
        /// <typeparam name="TQueryListResult">Type of Handler Result Object</typeparam>
        /// <typeparam name="TViewModelResult">Type of View Model</typeparam>
        /// <param name="query">Query Object</param>
        /// <returns>
        /// Response Model contain service result model.
        /// The service result is List.
        /// </returns>
        protected ResponseModelBase DoQueryList<TQuery, TQueryListResult, TViewModelResult>(TQuery query)
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

            //Map data result to view model
            var dataResult = handlerResult.Result.Items.Select(Mapper.Map<TQueryListResult, TViewModelResult>).ToList();

            //Queried succeed
            return new ResponseModelBase
            {
                Success = true,
                Count = handlerResult.Result.TotalRow,
                Data = dataResult
            };
        }

        /// <summary>
        ///  Call Async Command Handler
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TCommand"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        protected async Task<ActionResult<ResponseModelBase>> DoCommandAsync<TModel, TCommand>(RequestModelBase<TModel> model)
            where TCommand : ICommandBase
        {
            //Map data from Request Object to Command Object
            TCommand command = Mapper.Map<TCommand>(model);
            // Call Command Handler
            return await DoCommandAsync(command);
        }

        /// <summary>
        /// Call Async Query Item Handler
        /// </summary>
        /// <typeparam name="TQuery">Type of Query Single Object.</typeparam>
        /// <typeparam name="TQuerySingleResult">Type of Handler Result Object</typeparam>
        /// <typeparam name="TViewModelResult">Type of View Model</typeparam>
        /// <param name="query">Query Single Object</param>
        /// <returns>
        /// Response Model contain service result model.
        /// The service result is not Collection Object.
        /// </returns>
        //protected async Task<ResponseModelBase> DoQueryItemAsync<TQuery, TQuerySingleResult, TViewModelResult>(TQuery query)
        //    where TQuery : IQuerySingleBase
        //{
        //    //Call Async Query Item Handler
        //    var queryResult = await DoQueryItemAsync<TQuery, TQuerySingleResult>(query);

        //    if (!queryResult.Success)
        //    {
        //        return queryResult;
        //    }

        //    //Map Handler Result to View Model
        //    var dataResult = Mapper.Map<TViewModelResult>(queryResult.Data);

        //    return new ResponseModelBase
        //    {
        //        Success = true,
        //        Count = 1,
        //        Data = dataResult
        //    };
        //}

        /// <summary>
        /// Call Async Query List Handler
        /// </summary>
        /// <typeparam name="TQuery">Type of Query List Object</typeparam>
        /// <typeparam name="TQueryListResult">Type of Handler Result Object</typeparam>
        /// <typeparam name="TViewModelResult">Type of View Model</typeparam>
        /// <param name="query">Query List Object</param>
        /// <returns>
        /// Response Model contain service result model.
        /// The service result is List.
        /// </returns>
        //protected async Task<ResponseModelBase> DoQueryListAsync<TQuery, TQueryListResult, TViewModelResult>(TQuery query)
        //    where TQuery : IQueryListBase
        //{
        //    //Get query handler
        //    var service = HttpContext.RequestServices.GetService<IQueryListAsyncHandlerBase<TQuery, TQueryListResult>>();

        //    if (service == null)
        //    {
        //        return SERVICE_NOT_FOUND;
        //    }

        //    //Query Data
        //    var serviceResult = await service.QueryAsync(query);

        //    //If query handler return null
        //    if (serviceResult == null)
        //    {
        //        return SERVICE_NOT_FOUND;
        //    }

        //    //Got handled error(s)
        //    if (!serviceResult.Success)
        //    {
        //        return new ResponseModelBase
        //        {
        //            Success = false,
        //            Message = serviceResult.ErrorMessages
        //        };
        //    }

        //    //Map Handler Result to View Model
        //    var dataResult = serviceResult.Result.Select(Mapper.Map<TQueryListResult, TViewModelResult>).ToList();

        //    return new ResponseModelBase
        //    {
        //        Success = true,
        //        Count = serviceResult.TotalRow,
        //        Data = dataResult
        //    };
        //}
    }
}
