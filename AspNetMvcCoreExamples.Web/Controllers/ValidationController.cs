namespace AspNetMvc5Examples.Web.Controllers
{
    using AspNetMvcCoreExamples.Web.Models;
    using Microsoft.AspNetCore.Mvc;
    using AspNetMvcCoreExamples.Business.FlashMessages;

    public class ValidationController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult DataAnnotations()
        {
            var viewModel = new DataAnnotationsValidationViewModel();
            return this.View(viewModel);
        }

        [HttpPost]
        public IActionResult DataAnnotations(DataAnnotationsValidationViewModel viewModel)
        {
            if (this.ModelState.IsValid)
            {
                return this.RedirectToAction("Index", "Validation")
                    .WithSuccessAlert("Validation entity has been created");
            }

            return this.View(viewModel);
        }

        public IActionResult CodeValidation()
        {
            var viewModel = new CodeValidationViewModel();
            return this.View(viewModel);
        }

        [HttpPost]
        public IActionResult CodeValidation(CodeValidationViewModel viewModel)
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


        public IActionResult RemoteValidation()
        {
            var viewModel = new RemoteValidationViewModel();
            return this.View(viewModel);
        }

        [HttpPost]
        public IActionResult RemoteValidation(RemoteValidationViewModel viewModel)
        {
            if (this.ModelState.IsValid)
            {
                return this.RedirectToAction("Index", "Validation")
                    .WithSuccessAlert("Validation entity has been created");
            }

            return this.View(viewModel);
        }

        public IActionResult CustomValidationAttribute()
        {
            var viewModel = new CustomValidationAttributeViewModel();
            return this.View(viewModel);
        }

        [HttpPost]
        public IActionResult CustomValidationAttribute(CustomValidationAttributeViewModel viewModel)
        {
            if (this.ModelState.IsValid)
            {
                return this.RedirectToAction("Index", "Validation")
                    .WithSuccessAlert("Validation entity has been created");
            }

            return this.View(viewModel);
        }

        // LAB 9 - TODO
        public IActionResult Create()
        {
            var viewModel = new DataAnnotationsValidationViewModel();
            return this.View(viewModel);
        }
    }
}