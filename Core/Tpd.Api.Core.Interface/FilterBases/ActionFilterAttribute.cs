using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections;
using System.Linq;
using Tpd.Api.Core.Interface.RequestModelBases;
using Tpd.Api.Utility.SystemDateTime;

namespace Tpd.Api.Core.Interface
{
    public class ActionFilterAttribute : IActionFilter
    {
        private string localTimeZone { get; set; }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (IsModelValid(filterContext))
            {
                Globalize(filterContext);
            }
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (!string.IsNullOrEmpty(localTimeZone))
            {
                var result = (ObjectResult)filterContext.Result;
                Localize(result.Value);
            }
        }

        private void Globalize(ActionExecutingContext filterContext)
        {
            //var actionArguments = filterContext.ActionArguments;

            //foreach (var actionArgument in actionArguments)
            //{
            //    var argtype = actionArgument.Value.GetType();

            //    if (argtype.GetGenericTypeDefinition() == typeof(RequestModelBase<>))
            //    {
            //        var context = argtype.GetProperty("RequestContext")
            //                        .GetValue(actionArgument.Value) as RequestContext;

            //        localTimeZone = context.LocalTimeZone;

            //        var model = argtype.GetProperty("Model").GetValue(actionArgument.Value);

            //        if (model is IConvertTimeZone)
            //        {
            //            var value = model as IConvertTimeZone;

            //            if (value != null)
            //            {
            //                value.ConvertTimeZone(localTimeZone, AppCoreSettings.SystemTimeZone);
            //            }
            //        }
            //    }
            //}
        }

        private void Localize(object obj)
        {
            //if (obj == null)
            //{
            //    return;
            //}

            //var objectType = obj.GetType();

            //if (objectType.IsValueType)
            //{
            //    return;
            //}

            //if (obj is IEnumerable)
            //{
            //    var items = (IEnumerable)obj;
            //    foreach (var item in items)
            //    {
            //        Localize(item);
            //    }
            //    return;
            //}

            //if (obj is IConvertTimeZone) {
            //    ((IConvertTimeZone)obj).ConvertTimeZone(AppCoreSettings.SystemTimeZone, localTimeZone);
            //    return;
            //}

            //var properties = objectType.GetProperties();

            //foreach (var property in properties)
            //{
            //    var value = property.GetValue(obj);
            //    Localize(value);
            //}
        }

        private bool IsModelValid(ActionExecutingContext filterContext)
        {
            if (!filterContext.ModelState.IsValid)
            {
                var messages = filterContext.ModelState.Values.SelectMany(state => state.Errors)
                   .Select(s => s.ErrorMessage).ToList();

                var result = new JsonResult(new ResponseModelBase
                {
                    Success = false,
                    Message = messages
                });

                return false;
            }
            return true;
        }
    }
}
