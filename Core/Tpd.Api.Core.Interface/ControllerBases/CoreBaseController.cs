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
    //
    // Summary:
    //     The Abstract controller provide base functions to call services
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
        //
        // Summary:
        //     Injects a command handler to handle a command.
        //     Validates handler result then map to response data.
        // Return:
        //     Tpd.Api.Core.Interface.ResponseModelBase formated data to response to client
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
        //
        // Summary:
        //     Injects a command handler to handle a command.
        //     Validates handler result then map to response data.
        // Return:
        //     Tpd.Api.Core.Interface.ResponseModelBase formated data to response to client
        protected async Task<ResponseModelBase> DoCommandAsyncTask<TCommand>(TCommand command)
            where TCommand : ICommandBase
        {
            //Get command handler
            var handler = HttpContext.RequestServices.GetService<ICommandHandlerBaseAsyncTask<TCommand>>();

            if (handler == null)
            {
                return SERVICE_NOT_FOUND;
            }

            //Execute command
            var handlerResult = await handler.HandleAsyncTask(command);

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
        //
        // Summary:
        //     Injects a command handler to handle a command.
        //     Validates handler result then map to response data.
        protected void DoCommandAsyncVoid<TCommand>(TCommand command)
            where TCommand : ICommandBase
        {
            //Get command handler
            var handler = HttpContext.RequestServices.GetService<ICommandHandlerBaseAsyncVoid<TCommand>>();
            handler.HandleAsyncVoid(command);
        }
        //
        // Summary:
        //     Injects a query handler to handle a query.
        //     Validates handler result then map to response data.
        // Return:
        //     Tpd.Api.Core.Interface.ResponseModelBase formated data to response to client
        protected ResponseModelBase DoQuery<TQuery, TQuerySingleResult>(TQuery query)
        where TQuery : IQueryBase
        {
            var handler = HttpContext.RequestServices.GetService<IQueryHandlerBase<TQuery, TQuerySingleResult>>();

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
        //
        // Summary:
        //     Injects a query handler to handle a query.
        //     Validates handler result then map to response data.
        // Return:
        //     Tpd.Api.Core.Interface.ResponseModelBase formated data to response to client
        protected async Task<ResponseModelBase> DoQueryAsync<TQuery, TQuerySingleResult>(TQuery query)
        where TQuery : IQueryBase
        {
            var handler = HttpContext.RequestServices.GetService<IQueryHandlerBaseAsync<TQuery, TQuerySingleResult>>();

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

            //Queried succeed
            return new ResponseModelBase
            {
                Success = true,
                Count = 1,
                Data = handlerResult.Result
            };
        }
        //
        // Summary:
        //     Injects a query item handler to handle a query.
        //     Validates handler result then map to response data.
        // Return:
        //     Tpd.Api.Core.Interface.ResponseModelBase formated data to response to client
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
        //
        // Summary:
        //     Injects a query item handler to handle a query.
        //     Validates handler result then map to response data.
        // Return:
        //     Tpd.Api.Core.Interface.ResponseModelBase formated data to response to client
        protected async Task<ResponseModelBase> DoQueryItemAsync<TQuery, TQuerySingleResult>(TQuery query)
            where TQuery : IQuerySingleBase
        {
            //Get query handler
            var handler = HttpContext.RequestServices.GetService<IQuerySingleHandlerBaseAsync<TQuery, TQuerySingleResult>>();

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

            //Queried succeed
            return new ResponseModelBase
            {
                Success = true,
                Count = 1,
                Data = handlerResult.Result
            };
        }
        //
        // Summary:
        //     Injects a query list handler to handle a query.
        //     Validates handler result then map to response data.
        // Return:
        //     Tpd.Api.Core.Interface.ResponseModelBase formated data to response to client
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
        //
        // Summary:
        //     Injects a query list handler to handle a query.
        //     Validates handler result then map to response data.
        // Return:
        //     Tpd.Api.Core.Interface.ResponseModelBase formated data to response to client
        protected async Task<ResponseModelBase> DoQueryListAsync<TQuery, TQueryListResult>(TQuery query)
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

            //Queried succeed
            return new ResponseModelBase
            {
                Success = true,
                Count = handlerResult.Result.TotalRow,
                Data = handlerResult.Result
            };
        }
    }
}
