using Microsoft.AspNetCore.Mvc;

namespace AspNetMvc5Examples.Web.Controllers
{
    public class PartialViewAndActionController : Controller
    {
        // GET: PartialViewAndAction
        public IActionResult Index()
        {
            return this.View();
        }

        //[ChildActionOnly]
        //public PartialViewResult _Action()
        //{
        //    string viewModel = "Action";
        //    return this.PartialView(model: viewModel);
        //}
    }
}