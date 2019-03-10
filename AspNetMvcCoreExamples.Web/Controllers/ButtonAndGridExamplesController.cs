namespace AspNetMvc5Examples.Web.Controllers
{
    using AspNetMvcCoreExamples.Web.Data;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;

    public class ButtonAndGridExamplesController : Controller
    {
        private readonly ApplicationDbContext context;

        public ButtonAndGridExamplesController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Index(string title)
        {
            this.ViewBag.Message = title;
            return this.View();
        }

        public IActionResult GridView()
        {
            var movies = this.context.Movies.ToList();
            return this.View(movies);
        }
    }
}