namespace AspNetMvcCoreExamples.Business.Filters
{
    using Microsoft.AspNetCore.Mvc.Filters;
    using System.Diagnostics;

    public class BaseCustomActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var data = filterContext.RouteData;
            Debugger.Break(); // 2.
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var data = filterContext.RouteData;
            Debugger.Break(); // 4.
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            var data = filterContext.RouteData;
            Debugger.Break(); // 5.
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            var data = filterContext.RouteData;
            Debugger.Break(); // 6.
        }
    }
}
