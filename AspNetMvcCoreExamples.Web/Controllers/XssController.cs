namespace AspNetMvcCoreExamples.Web.Controllers
{
    using AspNetMvcCoreExamples.Web.Models;
    using Microsoft.AspNetCore.Mvc;

    public class XssController : Controller
    {
        // GET: Xss
        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Create()
        {
            var viewModel = new XssViewModel();
            return this.View(viewModel);
        }

        [HttpPost]
        // TODO [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(XssViewModel viewModel)
        {
            return this.View(viewModel);
        }
    }
}