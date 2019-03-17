using AutoMapper;
using Tpd.Api.Core.Service.RequestBases.CommandBases;
using Tpd.Api.Core.Service.RequestBases.QueryBases;
using Tpd.Api.Core.Service.HandlerBases.CommandHandlerBases;
using Tpd.Api.Core.Service.HandlerBases.QueryHandlerBases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tpd.Api.Core.Interface
{
    public class CoreBaseController : ControllerBase
    {
        protected readonly IMapper Mapper;

        private const string SERVICE_NOT_FOUND = "Service not found!";

        public CoreBaseController(IMapper mapper)
        {
            Mapper = mapper;
        }

        protected ResponseModelBase DoCommand<TCommand, TCommandResult>(TCommand command)
            where TCommand : ICommandBase
        {
            var service = HttpContext.RequestServices.GetService<ICommandHandlerBase<TCommand, TCommandResult>>();
            var serviceResult = service.Execute(command);

            if (serviceResult == null)
            {
                return new ResponseModelBase
                {
                    Success = false,
                    Message = new List<string>
                    {
                        SERVICE_NOT_FOUND
                    }
                };
            }

            if (!serviceResult.Success)
            {
                return new ResponseModelBase
                {
                    Success = false,
                    Message = serviceResult.ErrorMessages
                };
            }

            return new ResponseModelBase
            {
                Success = true,
                Count = 1,
                Data = serviceResult.Result
            };
        }

        protected ActionResult<ResponseModelBase> DoCommand<TModel, TCommand, TResult>(RequestModelBase<TModel> model)
            where TCommand : ICommandBase
        {
            TCommand command = Mapper.Map<TCommand>(model);
            return DoCommand<TCommand, TResult>(command);
        }

        protected ResponseModelBase DoQueryItem<TQuery, TQuerySingleResult>(TQuery query)
            where TQuery : IQuerySingleBase
        {
            var service = HttpContext.RequestServices.GetService<IQuerySingleHandlerBase<TQuery, TQuerySingleResult>>();
            var serviceResult = service.Query(query);

            if (serviceResult == null)
            {
                return new ResponseModelBase
                {
                    Success = false,
                    Message = new List<string>
                    {
                        SERVICE_NOT_FOUND
                    }
                };
            }

            if (!serviceResult.Success)
            {
                return new ResponseModelBase
                {
                    Success = false,
                    Message = serviceResult.ErrorMessages
                };
            }

            return new ResponseModelBase
            {
                Success = true,
                Count = 1,
                Data = serviceResult.Result
            };
        }

        protected ResponseModelBase DoQueryItem<TQuery, TQuerySingleResult, TViewModelResult>(TQuery query)
            where TQuery : IQuerySingleBase
        {

            var queryResult = DoQueryItem<TQuery, TQuerySingleResult>(query);

            if (!queryResult.Success)
            {
                return queryResult;
            }

            var dataResult = Mapper.Map<TViewModelResult>(queryResult.Data);

            return new ResponseModelBase
            {
                Success = true,
                Count = 1,
                Data = dataResult
            };
        }

        protected ResponseModelBase DoQueryList<TQuery, TQueryListResult>(TQuery query)
            where TQuery : IQueryListBase
        {
            var service = HttpContext.RequestServices.GetService<IQueryListHandlerBase<TQuery, TQueryListResult>>();
            var serviceResult = service.Query(query);

            if (serviceResult == null)
            {
                return new ResponseModelBase
                {
                    Success = false,
                    Message = new List<string>
                    {
                        SERVICE_NOT_FOUND
                    }
                };
            }

            if (!serviceResult.Success)
            {
                return new ResponseModelBase
                {
                    Success = false,
                    Message = serviceResult.ErrorMessages
                };
            }

            return new ResponseModelBase
            {
                Success = true,
                Count = serviceResult.TotalRow,
                Data = serviceResult.Result
            };

        }

        protected ResponseModelBase DoQueryList<TQuery, TQueryListResult, TViewModelResult>(TQuery query)
            where TQuery : IQueryListBase
        {
            var service = HttpContext.RequestServices.GetService<IQueryListHandlerBase<TQuery, TQueryListResult>>();
            var serviceResult = service.Query(query);

            if (serviceResult == null)
            {
                return new ResponseModelBase
                {
                    Success = false,
                    Message = new List<string>
                    {
                        SERVICE_NOT_FOUND
                    }
                };
            }

            if (!serviceResult.Success)
            {
                return new ResponseModelBase
                {
                    Success = false,
                    Message = serviceResult.ErrorMessages
                };
            }

            var dataResult = serviceResult.Result.Select(Mapper.Map<TQueryListResult, TViewModelResult>).ToList();

            return new ResponseModelBase
            {
                Success = true,
                Count = serviceResult.TotalRow,
                Data = dataResult
            };
        }

        protected async Task<ResponseModelBase> DoCommandAsync<TCommand, TCommandResult>(TCommand command)
            where TCommand : ICommandBase
        {
            var service = HttpContext.RequestServices.GetService<ICommandAsyncHandlerBase<TCommand, TCommandResult>>();
            var serviceResult = await service.Execute(command);

            if (serviceResult == null)
            {
                return new ResponseModelBase
                {
                    Success = false,
                    Message = new List<string>
                    {
                        SERVICE_NOT_FOUND
                    }
                };
            }

            if (!serviceResult.Success)
            {
                return new ResponseModelBase
                {
                    Success = false,
                    Message = serviceResult.ErrorMessages
                };
            }

            return new ResponseModelBase
            {
                Success = true,
                Count = 1,
                Data = serviceResult.Result
            };
        }

        protected async Task<ActionResult<ResponseModelBase>> DoCommandAsync<TModel, TCommand, TResult>(RequestModelBase<TModel> model)
            where TCommand : ICommandBase
        {
            TCommand command = Mapper.Map<TCommand>(model);
            return await DoCommandAsync<TCommand, TResult>(command);
        }

        protected async Task<ResponseModelBase> DoQueryItemAsync<TQuery, TQuerySingleResult>(TQuery query)
            where TQuery : IQuerySingleBase
        {
            var service = HttpContext.RequestServices.GetService<IQuerySingleAsyncHandlerBase<TQuery, TQuerySingleResult>>();
            var serviceResult = await service.Query(query);

            if (serviceResult == null)
            {
                return new ResponseModelBase
                {
                    Success = false,
                    Message = new List<string>
                    {
                        SERVICE_NOT_FOUND
                    }
                };
            }

            if (!serviceResult.Success)
            {
                return new ResponseModelBase
                {
                    Success = false,
                    Message = serviceResult.ErrorMessages
                };
            }

            return new ResponseModelBase
            {
                Success = true,
                Count = 1,
                Data = serviceResult.Result
            };
        }

        protected async Task<ResponseModelBase> DoQueryItemAsync<TQuery, TQuerySingleResult, TViewModelResult>(TQuery query)
            where TQuery : IQuerySingleBase
        {

            var queryResult = await DoQueryItemAsync<TQuery, TQuerySingleResult>(query);

            if (!queryResult.Success)
            {
                return queryResult;
            }

            var dataResult = Mapper.Map<TViewModelResult>(queryResult.Data);

            return new ResponseModelBase
            {
                Success = true,
                Count = 1,
                Data = dataResult
            };
        }

        protected async Task<ResponseModelBase> DoQueryListAsync<TQuery, TQueryListResult>(TQuery query)
            where TQuery : IQueryListBase
        {
            var service = HttpContext.RequestServices.GetService<IQueryListAsyncHandlerBase<TQuery, TQueryListResult>>();
            var serviceResult = await service.Query(query);

            if (serviceResult == null)
            {
                return new ResponseModelBase
                {
                    Success = false,
                    Message = new List<string>
                    {
                        SERVICE_NOT_FOUND
                    }
                };
            }

            if (!serviceResult.Success)
            {
                return new ResponseModelBase
                {
                    Success = false,
                    Message = serviceResult.ErrorMessages
                };
            }

            return new ResponseModelBase
            {
                Success = true,
                Count = serviceResult.TotalRow,
                Data = serviceResult.Result
            };

        }

        protected async Task<ResponseModelBase> DoQueryListAsync<TQuery, TQueryListResult, TViewModelResult>(TQuery query)
            where TQuery : IQueryListBase
        {
            var service = HttpContext.RequestServices.GetService<IQueryListAsyncHandlerBase<TQuery, TQueryListResult>>();
            var serviceResult = await service.Query(query);

            if (serviceResult == null)
            {
                return new ResponseModelBase
                {
                    Success = false,
                    Message = new List<string>
                    {
                        SERVICE_NOT_FOUND
                    }
                };
            }

            if (!serviceResult.Success)
            {
                return new ResponseModelBase
                {
                    Success = false,
                    Message = serviceResult.ErrorMessages
                };
            }

            var dataResult = serviceResult.Result.Select(Mapper.Map<TQueryListResult, TViewModelResult>).ToList();

            return new ResponseModelBase
            {
                Success = true,
                Count = serviceResult.TotalRow,
                Data = dataResult
            };
        }

    }
}
