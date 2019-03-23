using ElmahCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;

namespace Tpd.Api.Core.Interface
{
    public class ActionExceptionFilterAttribute : ExceptionFilterAttribute
    {
        /// <summary>
        /// The function for catching action exception
        /// </summary>
        /// <param name="context"></param>
        public override void OnException(ExceptionContext context)
        {
            //For Elmah log
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

            //Return custome data
            context.Result = result;
        }
    }
}
