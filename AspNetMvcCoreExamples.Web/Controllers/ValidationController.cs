namespace AspNetMvc5Examples.Web.Controllers
{
    using System.Web.Mvc;
    using AspNetMvc5Examples.Web.Models;
    using AspNetMvcExamples.Business.FlashMessages;

    public class ValidationController : Controller
    {
        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult DataAnnotations()
        {
            var viewModel = new DataAnnotationsValidationViewModel();
            return this.View(viewModel);
        }

        [HttpPost]
        public ActionResult DataAnnotations(DataAnnotationsValidationViewModel viewModel)
        {
            if (this.ModelState.IsValid)
            {
                return this.RedirectToAction("Index", "Validation")
                    .WithSuccessAlert("Validation entity has been created");
            }

            return this.View(viewModel);
        }

        public ActionResult CodeValidation()
        {
            var viewModel = new CodeValidationViewModel();
            return this.View(viewModel);
        }

        [HttpPost]
        public ActionResult CodeValidation(CodeValidationViewModel viewModel)
        {
            if (viewModel.Property != 0)
            {
                this.ModelState.AddModelError(nameof(CodeValidationViewModel.Property), "Property has to be 0");
            }

            if (this.ModelState.IsValid)
            {
                return this.RedirectToAction("Index", "Validation")
                    .WithSuccessAlert("Validation entity has been created");
            }

            return this.View(viewModel);
        }


        public ActionResult RemoteValidation()
        {
            var viewModel = new RemoteValidationViewModel();
            return this.View(viewModel);
        }

        [HttpPost]
        public ActionResult RemoteValidation(RemoteValidationViewModel viewModel)
        {
            if (this.ModelState.IsValid)
            {
                return this.RedirectToAction("Index", "Validation")
                    .WithSuccessAlert("Validation entity has been created");
            }

            return this.View(viewModel);
        }

        public ActionResult CustomValidationAttribute()
        {
            var viewModel = new CustomValidationAttributeViewModel();
            return this.View(viewModel);
        }

        [HttpPost]
        public ActionResult CustomValidationAttribute(CustomValidationAttributeViewModel viewModel)
        {
            if (this.ModelState.IsValid)
            {
                return this.RedirectToAction("Index", "Validation")
                    .WithSuccessAlert("Validation entity has been created");
            }

            return this.View(viewModel);
        }

        // LAB 9 - TODO
        public ActionResult Create()
        {
            var viewModel = new DataAnnotationsValidationViewModel();
            return this.View(viewModel);
        }
    }
}