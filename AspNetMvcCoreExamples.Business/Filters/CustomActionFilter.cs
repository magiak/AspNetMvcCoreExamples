namespace AspNetMvcCoreExamples.Business.Filters
{
    using Microsoft.AspNetCore.Mvc.Filters;
    using System.Diagnostics;

    public class CustomActionFilter : ActionFilterAttribute // FilterAttribute, 
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Debugger.Break(); // 2.
            Debug.WriteLine("CustomActionFilter.OnActionExecuting");
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Debugger.Break(); // 4.
            Debug.WriteLine("CustomActionFilter.OnActionExecuted");
        }
    }
}
