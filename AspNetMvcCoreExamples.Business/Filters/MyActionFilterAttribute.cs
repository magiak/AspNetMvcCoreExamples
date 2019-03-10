namespace AspNetMvcCoreExamples.Business.Filters
{
    using Microsoft.AspNetCore.Mvc.Filters;

    public class MyActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //Debugger.Break();

            // This is to late
            //filterContext.RequestContext.RouteData.Values.Remove("action");
            //filterContext.RequestContext.RouteData.Values.Add("action", "Test2");


            // filterContext.Result is null;

            //filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
            //{
            //    controller = "Filter",
            //    action = "Test2"
            //}));
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            // filter.Result is ContentResult

            //Debugger.Break();
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            //Debugger.Break();
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            //Debugger.Break();
        }
    }
}
