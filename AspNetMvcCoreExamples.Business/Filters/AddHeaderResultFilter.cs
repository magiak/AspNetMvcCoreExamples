using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace AspNetMvcCoreExamples.Business.Filters
{
    public class AddHeaderResultFilter : ResultFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.Headers.Add("X-MyHeader", DateTime.Today.ToShortDateString());
        }
    }
}
