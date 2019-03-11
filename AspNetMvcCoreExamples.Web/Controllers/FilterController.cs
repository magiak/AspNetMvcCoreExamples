namespace AspNetMvcCoreExamples.Web.Controllers
{
    using System;
    using System.Diagnostics;
    using AspNetMvcCoreExamples.Business.Filters;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;

    public class FilterController : Controller
    {
        //[AuthorizationFilter]
        [CustomActionFilter]
        [ResultFilter]
        [ExceptionFilter]
        // [BaseCustomActionFilter] // ActionFilterAttribute = easy way to implement CustomActionFilter and ResultFilter
        public IActionResult Index()
        {
            Debugger.Break(); // 3.
            // throw new Exception("This will be catched by ExceptionFilter");
            return this.Content("Hello from FilterController.");
        }

        // GET: OutputCache
        //[OutputCache(Duration = 10)]
        [ResponseCache(Duration = 3600)]
        public IActionResult OutputCache()
        {
            return this.Content(DateTime.Now.ToString());
        }

        [MyActionFilter]
        public IActionResult Test()
        {
            return this.Content("Hello wordl");
        }

        public IActionResult Test2()
        {
            return this.Content("Hello wordl 2");
        }
    }
}