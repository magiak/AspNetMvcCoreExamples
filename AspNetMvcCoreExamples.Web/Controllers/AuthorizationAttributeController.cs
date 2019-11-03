namespace AspNetMvcCoreExamples.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    //[Authorize]
    public class AuthorizationAttributeController : Controller
    {
        // GET: AuthorizationAttribute
        public IActionResult Public()
        {
            return this.View();
        }

        [Authorize]
        public IActionResult Secret()
        {
            return this.View();
        }

        //[AllowAnonymous]
        public IActionResult AllowAnonymous()
        {
            return this.View();
        }

        [Authorize("IsAdmin")]
        public IActionResult AllowedWithClaim()
        {
            return this.View();
        }

        [Authorize("AtLeast21")]
        public IActionResult AtLeast21Allowed()
        {
            return this.View();
        }
    }
} 