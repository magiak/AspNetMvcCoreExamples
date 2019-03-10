namespace AspNetMvcCoreExamples.Business.Filters
{
    using Microsoft.AspNetCore.Mvc.Filters;
    using System.Diagnostics;

    public class ResultFilter : ResultFilterAttribute 
    {
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            Debugger.Break(); // 5.
            Debug.WriteLine("ResultFilter.OnResultExecuting");
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            Debugger.Break(); // 6.
            Debug.WriteLine("ResultFilter.OnResultExecuted");
        }
    }
}
