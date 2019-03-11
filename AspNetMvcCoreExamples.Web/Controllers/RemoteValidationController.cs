using Microsoft.AspNetCore.Mvc;

namespace AspNetMvcCoreExamples.Web.Controllers
{
    public class RemoteValidationController : Controller
    {
        // GET: RemoteValidation
        public JsonResult ValidateRemoteAttribute(string remoteAttribute)
        {
            if (remoteAttribute.ToLower().StartsWith("h"))
            {
                return this.Json(true);
            }

            return this.Json("Value has to starts with character 'H'");
        }
    }
}