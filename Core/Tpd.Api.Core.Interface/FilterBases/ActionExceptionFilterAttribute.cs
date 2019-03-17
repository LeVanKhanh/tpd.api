using ElmahCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;

namespace Tpd.Api.Core.Interface
{
    public class ActionExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            context.HttpContext.RiseError(context.Exception);

            string message = context.Exception.Message;
            var result = new JsonResult(new ResponseModelBase
            {
                Success = false,
                Message = new List<string>
                 {
                     message
                 }
            });

            context.Result = result;
        }
    }
}
