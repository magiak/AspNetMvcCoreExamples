using Microsoft.AspNetCore.Mvc;

namespace AspNetMvcCoreExamples.Web.Controllers
{
    public class ViewBagViewDataAndTempDataController : Controller
    {
        public IActionResult ViewBagAction()
        {
            this.ViewBag.MyObject = "Hello, from view bag";
            return this.View();
        }

        public IActionResult ViewDataAction()
        {
            this.ViewData["MyObject"] = "Hello, from view data";
            //this.ViewBag.MyObject = "Hello, from view bag"; override value set to ViewData!
            return this.View();
        }

        public IActionResult TempDataAction()
        {
            this.TempData["MyObject"] = "Hello, from temp data"; // try with viewdata
            return this.RedirectToAction("TempDataAction2");
        }

        public IActionResult TempDataAction2()
        {
            return this.Content(this.TempData["MyObject"].ToString());
        }
    }
}