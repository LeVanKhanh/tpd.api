using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace Tpd.Api.Core.Interface
{
    public class ActionFilterAttribute : IActionFilter
    {
        /// <summary>
        /// The function for valivdating model of each action
        /// </summary>
        /// <param name="filterContext"></param>
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!filterContext.ModelState.IsValid)
            {
                var messages = filterContext.ModelState.Values.SelectMany(state => state.Errors)
                   .Select(s => s.ErrorMessage).ToList();

                //Return custome data
                var result = new JsonResult(new ResponseModelBase
                {
                    Success = false,
                    Message = messages
                });
            }
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {

        }
    }
}
