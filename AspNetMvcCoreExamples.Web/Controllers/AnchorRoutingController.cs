using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AspNetMvcCoreExamples.Web.Controllers
{
    public class AnchorRoutingController : Controller
    {
        public IActionResult Index(string lang)
        {
            return View(model: lang);
        }
    }
}