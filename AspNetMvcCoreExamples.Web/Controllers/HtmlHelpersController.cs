namespace AspNetMvcCoreExamples.Web.Controllers
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using AspNetMvcCoreExamples.Business.FlashMessages;
    using AspNetMvcCoreExamples.Web.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class HtmlHelpersController : Controller
    {
        // GET: EditorAndDisplayTemplates
        public IActionResult EditorAndDisplayTemplates()
        {
            var viewModel = new EditorAndDisplayTemplatesViewModel();
            this.InitializeViewModel(viewModel);
            return this.View(viewModel);
        }

        public IActionResult Modal()
        {
            return this.View();
        }

        public IActionResult FlashMessages()
        {
            this.TempData.AddAlert(AlertType.Success, "My awesome bootstrap alert from custom HTML Helper");
            this.TempData.AddAlert(AlertType.Danger, "Something went terribly wrong here");

            return this.View();
        }

        public IActionResult InlineHelper()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult EditorAndDisplayTemplates(EditorAndDisplayTemplatesViewModel viewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction("Index", "Home")
                    .WithSuccessAlert("Entity has been created");
            }

            this.InitializeViewModel(viewModel);
            return this.View(viewModel);
        }

        public void InitializeViewModel(EditorAndDisplayTemplatesViewModel viewModel)
        {
            viewModel.Price = 42;
            viewModel.MonthItems = GetMonthSelectListItems().ToList();
        }

        public static IEnumerable<SelectListItem> GetMonthSelectListItems()
        {
            for (int i = 1; i <= 12; i++)
            {
                yield return new SelectListItem
                {
                    Value = i.ToString(),
                    Text = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i)
                };
            }
        }
    }
}