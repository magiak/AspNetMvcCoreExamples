namespace AspNetMvcCoreExamples.Business.Filters
{
    using Microsoft.AspNetCore.Mvc.Filters;
    using System.Diagnostics;

    public class AuthorizationFilter : IAuthorizationFilter // FilterAttribute, 
    {
        public void OnAuthorization(AuthorizationFilterContext filterContext)
        {
            Debugger.Break(); // 1.
            Debug.WriteLine("AuthorizationFilter.OnAuthorization");
        }
    }
}
