using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetMvcCoreExamples.Web.Data;
using Microsoft.AspNetCore.Mvc;

namespace AspNetMvcCoreExamples.Web.Controllers
{
    public class ViewModel
    {
        private readonly ApplicationDbContext dbContext;

        public ViewModel(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public string MyProperty { get; set; }

        public void Initialize()
        {
            MyProperty = dbContext.Users.First().Email;
        }
    }

    public class InjectViewModelController : Controller
    {
        public InjectViewModelController(ViewModel viewModel)
        {
            this.ViewModel = viewModel;
        }

        public ViewModel ViewModel { get; }

        public IActionResult Index()
        {
            this.ViewModel.Initialize();


            return View(ViewModel);
        }
    }
}