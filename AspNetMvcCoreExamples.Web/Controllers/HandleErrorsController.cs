namespace AspNetMvcCoreExamples.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Net;

    public class HandleErrorsController : Controller
    {
        // GET: HandleErrors
        public IActionResult ExceptionAction()
        {
            throw new Exception();
        }

        public IActionResult BadRequestAction()
        {
            return this.StatusCode((int)HttpStatusCode.BadRequest);
        }

        public IActionResult UnauthorizedAction()
        {
            return this.StatusCode((int)HttpStatusCode.Unauthorized);
        }

        public IActionResult InternalServerErrorAction()
        {
            return this.StatusCode((int)HttpStatusCode.InternalServerError);
        }
    }
}