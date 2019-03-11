using AspNetMvcCoreExamples.Entities.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AspNetMvcCoreExamples.Web.Controllers
{
    public class JQueryController : Controller
    {
        // GET: JQuery
        public IActionResult Index()
        {
            return this.View();
        }

        // TODO [JsonNetFilter]
        public IActionResult Get()
        {
            var data = new MovieViewModel {
                Title = "Pelisky",
                ReleasedDate = new DateTime(1999, 4, 8)
            };

            //return new JsonNetResult { JsonRequestBehavior = behavior, Data = data };

            //return this.Json(
            //    data,
            //    behavior);

            return PartialView("_LoginPartial");
        }

        public IActionResult Post(string title)
        {
            return this.Content(title);
        }
    }
}