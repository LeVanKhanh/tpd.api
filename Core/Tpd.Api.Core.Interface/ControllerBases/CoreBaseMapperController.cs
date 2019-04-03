using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;
using Tpd.Api.Core.Service.HandlerBases.QueryHandlerBases;
using Tpd.Api.Core.Service.RequestBases.CommandBases;
using Tpd.Api.Core.Service.RequestBases.QueryBases;

namespace Tpd.Api.Core.Interface.ControllerBases
{
    //
    // Summary:
    //     The Abstract controller provide base functions to call services with automapper
    public abstract class CoreBaseMapperController : CoreBaseController
    {
        protected readonly IMapper Mapper;

        public CoreBaseMapperController(IMapper mapper)
        {
            Mapper = mapper;
        }
        //
        // Summary:
        //     Maps received data from client to service command.
        //     Calls action perform the command.
        // Return:
        //     Tpd.Api.Core.Interface.ResponseModelBase formated data to response to client
        protected ActionResult<ResponseModelBase> DoCommand<TModel, TCommand>(RequestModelBase<TModel> request)
           where TCommand : ICommandBase
        {
            //Map data from Request Object to Command Object
            TCommand command = Mapper.Map<TCommand>(request);
            // Call Command Handler
            return DoCommand(command);
        }
        //
        // Summary:
        //     Maps received data from client to service command.
        //     Calls action perform the command.
        // Return:
        //     Tpd.Api.Core.Interface.ResponseModelBase formated data to response to client
        protected async Task<ActionResult<ResponseModelBase>> DoCommandAsyncTask<TModel, TCommand>(RequestModelBase<TModel> request)
           where TCommand : ICommandBase
        {
            //Map data from Request Object to Command Object
            TCommand command = Mapper.Map<TCommand>(request);
            // Call Command Handler
            return await DoCommandAsyncTask(command);
        }
        //
        // Summary:
        //     Maps received data from client to service command.
        //     Calls action perform the command.
        protected void DoCommandAsyncVoid<TModel, TCommand>(RequestModelBase<TModel> request)
           where TCommand : ICommandBase
        {
            //Map data from Request Object to Command Object
            TCommand command = Mapper.Map<TCommand>(request);
            // Call Command Handler
            DoCommandAsyncVoid(command);
        }
        //
        // Summary:
        //     Calls action perform the query item.
        //     Maps the handler result to view model.
        // Return:
        //     Tpd.Api.Core.Interface.ResponseModelBase formated data to response to client
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
        //
        // Summary:
        //     Calls action perform the query item.
        //     Maps the handler result to view model.
        // Return:
        //     Tpd.Api.Core.Interface.ResponseModelBase formated data to response to client
        protected async Task<ResponseModelBase> DoQueryItemAsync<TQuery, TQuerySingleResult, TViewModelResult>(TQuery query)
            where TQuery : IQuerySingleBase
        {
            //Call Query Handler
            var queryResult = await DoQueryItemAsync<TQuery, TQuerySingleResult>(query);

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
        //
        // Summary:
        //     Calls action perform the query item by id.
        //     Maps the handler result to view model.
        // Return:
        //     Tpd.Api.Core.Interface.ResponseModelBase formated data to response to client
        protected ResponseModelBase DoQueryItemById<TQuerySingleResult, TViewModelResult>(Guid id)
        {
            var query = new QueryByIdBase
            {
                Id = id
            };

            //Call Query Handler
            return DoQueryItem<QueryByIdBase, TQuerySingleResult, TViewModelResult>(query);
        }
        //
        // Summary:
        //     Calls action perform the query list.
        //     Maps the handler result to view model.
        // Return:
        //     Tpd.Api.Core.Interface.ResponseModelBase formated data to response to client
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
        //
        // Summary:
        //     Calls action perform the query list.
        //     Maps the handler result to view model.
        // Return:
        //     Tpd.Api.Core.Interface.ResponseModelBase formated data to response to client
        protected async Task<ResponseModelBase> DoQueryListAsync<TQuery, TQueryListResult, TViewModelResult>(TQuery query)
            where TQuery : IQueryListBase
        {
            //Get query handler
            var handler = HttpContext.RequestServices.GetService<IQueryListHandlerBaseAsync<TQuery, TQueryListResult>>();

            if (handler == null)
            {
                return SERVICE_NOT_FOUND;
            }

            //Query Data
            var handlerResult = await handler.HandleAsyncTask(query);

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
    }
}
