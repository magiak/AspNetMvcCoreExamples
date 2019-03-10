using Microsoft.AspNetCore.Mvc;

namespace AspNetMvcCoreExamples.Web.Models
{
    public class RemoteValidationViewModel
    {
        [Remote("ValidateRemoteAttribute", "RemoteValidation")]
        public string RemoteAttribute { get; set; }
    }
}