namespace AspNetMvcCoreExamples.Business.Filters
{
    using Microsoft.AspNetCore.Mvc.Filters;
    using System.Diagnostics;

    public class ExceptionFilter : ExceptionFilterAttribute // FilterAttribute, 
    {
        public override void OnException(ExceptionContext filterContext)
        {
            Debugger.Break(); // 7.
            Debug.WriteLine("ExceptionFilter.OnException");
        }
    }
}
