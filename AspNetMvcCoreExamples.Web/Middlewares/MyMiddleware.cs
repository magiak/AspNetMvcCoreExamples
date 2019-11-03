using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace AspNetMvcCoreExamples.Web.Middlewares
{
    public class MyMiddleware
    {
        private readonly RequestDelegate _next;

        public MyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            context.Items["myMiddlewareKey"] = "Value from the middleware";

            // Call the next delegate/middleware in the pipeline
            await _next(context);
        }
    }

    public static class MiddlewareExtensions
    {
        public static void UseMyMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<MyMiddleware>();
        }
    }
}
