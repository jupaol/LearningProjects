using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Msts.Mvc.Filters
{
    public class FilterLifeCycle : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.HttpContext.Trace.Warn("FilterLifeCycle", MethodInfo.GetCurrentMethod().Name);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            filterContext.HttpContext.Trace.Warn("FilterLifeCycle", MethodInfo.GetCurrentMethod().Name);
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            filterContext.HttpContext.Trace.Warn("FilterLifeCycle", MethodInfo.GetCurrentMethod().Name);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            filterContext.HttpContext.Trace.Warn("FilterLifeCycle", MethodInfo.GetCurrentMethod().Name);
        }
    }
}