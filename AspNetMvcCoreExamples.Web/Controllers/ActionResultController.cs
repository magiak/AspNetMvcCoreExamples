using AspNetMvcCoreExamples.Entities.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AspNetMvcCoreExamples.Web.Controllers
{
    public class ActionResultController : Controller // TODO AspNetMvc5ExamplesControllerBase
    {
        public IActionResult EmptyAction()
        {
            return new EmptyResult();
        }

        public IActionResult ContentAction()
        {
            return this.Content("Hello from MVC application. <br /> This is awesome ContentActionResult!");
        }

        public IActionResult HttpNotFoundAction()
        {
            return this.NotFound(); // HttpNotFound
        }

        public IActionResult JsonAction()
        {
            var viewModel = new MovieViewModel
            {
                Title = "Pelisky"
            };

            return this.Json(viewModel);
        }


        //public IActionResult LineBreaksContentAction()
        //{
        //    return this.LineBreaksContent("Hello from MVC application. This is awesome ContentActionResult!");
        //}

        //public IActionResult HtmlAction(string title = null, string body = null)
        //{
        //    return this.Html(title, body); // AspNetMvc5ExamplesControllerBase
        //}

        //public IActionResult XmlAction()
        //{
        //    XmlModel obj = new XmlModel
        //    {
        //        Name = "Hello",
        //        Child = new XmlChildModel
        //        {
        //            ChildName = "World"
        //        }
        //    };

        //    return this.Xml(obj); // Extension
        //}

        //public IActionResult ViewEngineAction()
        //{
        //    return this.DummyView(new { Title = "ASP.NET MVC 5" });
        //}

        public IActionResult CustomViewEngine()
        {
            return this.View();
        }

        public IActionResult ViewBagAction()
        {
            this.ViewBag.MyKey = "Hi";
            //this.ViewBag["mykey2"] = "Hi 2";
            return this.View();
        }

        public IActionResult ViewDataAction()
        {
            this.ViewData["mykey"] = "Hi";
            return this.View();
        }

        public IActionResult MyRedirectAction()
        {
            this.TempData["mykey"] = "Hi";
            return this.RedirectToAction("MyRedirectAction2");
        }

        public IActionResult MyRedirectAction2()
        {
            var result = this.TempData["mykey"].ToString();
            return this.Content(result);
        }

        //public IActionResult FileAction()
        //{
        //    return File(Server.MapPath("~/Content/site.css"), "text/css");
        //}

        //public IActionResult ActionAsPdfAction()
        //{
        //    return new ActionAsPdf("PDF") { FileName = "Test.pdf" };
        //}

        public IActionResult PDF()
        {
            return this.View();
        }

        //public IActionResult ViewPdfAction()
        //{
        //    return new ViewAsPdf("ViewPdfAction");
        //}
    }
}