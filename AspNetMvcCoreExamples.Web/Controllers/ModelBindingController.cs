namespace AspNetMvc5Examples.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using AspNetMvcCoreExamples.Business.ModelBinding;
    using AspNetMvcCoreExamples.Web.Models;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;

    public class ModelBindingController : Controller
    {
        // MissingMethodException: Cannot create an instance of an interface.
        public IActionResult IQueryable(IQueryable<int> values)
        {
            return this.Json(values);
        }

        public IActionResult BasicMappingAnchor()
        {
            return View();
        }

        public IActionResult BasicMappingForm()
        {
            return View(new ModelBinderViewModel());
        }

        [HttpPost]
        public IActionResult BasicMappingForm(ModelBinderViewModel model)
        {
            return this.Json(model);
        }

        #region Basic Binding
        public IActionResult BindToString(string value)
        {
            Debugger.Break();
            return this.Content(value);
        }

        public IActionResult BindToInt(int value)
        {
            Debugger.Break();
            return this.Content(value.ToString());
        }

        public IActionResult BindToDateTime(DateTime value)
        {
            Debugger.Break();
            return this.Content(value.ToLongDateString());
        }

        public IActionResult BindToViewModel(ModelBinderViewModel viewModel)
        {
            var json = JsonConvert.SerializeObject(viewModel, Formatting.Indented);
            Debugger.Break();
            return this.Content(json);
        }

        public IActionResult BindToChildViewModel(ModelBinderViewModel viewModel)
        {
            var json = JsonConvert.SerializeObject(viewModel, Formatting.Indented);
            Debugger.Break();
            return this.Content(json);
        }

        //// TODO Black list
        //public IActionResult BindToViewModelExclude([Bind(Exclude = nameof(ModelBinderViewModel.Name))]ModelBinderViewModel viewModel)
        //{
        //    var data = this.HttpContext.Request.Form;
        //    var json = JsonConvert.SerializeObject(viewModel, Formatting.Indented);
        //    Debugger.Break();
        //    return this.Content(json);
        //}

        // White list
        public IActionResult BindToViewModelInclude([Bind(nameof(ModelBinderViewModel.Name))]ModelBinderViewModel viewModel)
        {
            var data = this.HttpContext.Request.Form;
            var json = JsonConvert.SerializeObject(viewModel, Formatting.Indented);
            Debugger.Break();
            return this.Content(json);
        }
        #endregion

        #region Array Binding

        public IActionResult BindToValueTypeListInput()
        {
            return View();
        }

        public IActionResult BindToValueTypeListHtmlHelper()
        {
            var list = new List<int> { 1, 2, 3 };

            return this.View(list);
        }

        [HttpPost]
        public IActionResult BindToValueTypeList(List<int> array)
        {
            if(array == null)
            {
                return new EmptyResult();
            }

            return this.Content(string.Join(",", array));
        }

        public IActionResult BindToReferenceTypeList()
        {
            var list = new List<ModelBinderArrayViewModel>
            {
                new ModelBinderArrayViewModel { Value = "1. value" },
                new ModelBinderArrayViewModel { Value = "2. value" },
                new ModelBinderArrayViewModel { Value = "3. value" },
            };

            return this.View(list);
        }

        [HttpPost]
        public IActionResult BindToReferenceTypeList(List<ModelBinderArrayViewModel> list)
        {
            return this.Content(string.Join(",", list.Select(x => x.Value)));
        }

        public IActionResult BindToReferenceTypeNonSequentialList()
        {
            var list = new List<ModelBinderArrayViewModel>
            {
                new ModelBinderArrayViewModel { Index = "1index", Value = "1. value" },
                new ModelBinderArrayViewModel { Index = "2index", Value = "2. value" },
                new ModelBinderArrayViewModel { Index = "3index", Value = "3. value" },
            };

            return this.View(list);
        }

        [HttpPost]
        public IActionResult BindToReferenceTypeNonSequentialList(IEnumerable<ModelBinderArrayViewModel> list)
        {
            return this.Content(string.Join(",", list.Select(x => x.Value)));
        }

        public PartialViewResult _ModelBinderArrayViewModel()
        {
            var viewModel = new ModelBinderArrayViewModel();

            return this.PartialView(viewModel);
        }
        #endregion

        #region View Model Binding
        // This action prepares data for JsonModelBinder
        public IActionResult BindToChild()
        {
            return this.View(new ModelBinderViewModel());
        }

        [HttpPost]
        public IActionResult BindToChild(ModelBinderViewModel viewModel)
        {
            if (this.ModelState.IsValid)
            {
                var json = JsonConvert.SerializeObject(viewModel, Formatting.Indented);
                return this.Content(json);
            }

            return this.View(viewModel);
        }

        #endregion

        #region Custom Model Binding
        public IActionResult JsonModelBinder()
        {
            var viewModel = new JsonViewModel();
            return this.View(viewModel);
        }

        [HttpPost]
        public IActionResult JsonModelBinder([ModelBinder(typeof(JsonModelBinder))] ModelBinderViewModel viewModel)
        {
            if (this.ModelState.IsValid)
            {
                Debugger.Break();

                var json = JsonConvert.SerializeObject(viewModel, Formatting.Indented);
                return this.Content(json);
            }

            return this.View(this.HttpContext.Request.Form[nameof(JsonViewModel.Json)]);
        }

        public IActionResult CreateDayMonthYear()
        {
            var viewModel = new DayMonthYearViewModel();
            return this.View(viewModel);
        }

        [HttpPost]
        public IActionResult CreateDayMonthYear([ModelBinder(typeof(DayMonthYearModelBinder))]DateTime date)
        {
            if (this.ModelState.IsValid)
            {
                Debugger.Break();

                return this.Content(date.ToShortDateString());
            }

            var viewModel = new DayMonthYearViewModel()
            {
                Day = date.Day,
                Month = date.Month,
                Year = date.Year
            };

            return this.View(viewModel);
        }
        #endregion

        #region Array, List, IEnumerable, HashSet, ...
        public IActionResult Array(int[] values)
        {
            return this.Json(values);
        }

        public IActionResult List(List<int> values)
        {
            return this.Json(values);
        }

        public IActionResult IEnumerable(IEnumerable<int> values)
        {
            return this.Json(values);
        }

        public IActionResult ICollection(ICollection<int> values)
        {
            return this.Json(values);
        }

        public IActionResult HashSet(HashSet<int> values)
        {
            return this.Json(values);
        }
        #endregion

        #region Value providers
        public IActionResult SessionValueProvider()
        {
            this.HttpContext.Session.SetString("myValue", "Hello world");

            return this.View();
        }

        [HttpPost]
        public IActionResult SessionValueProvider(string myValue)
        {
            return this.Content(this.HttpContext.Session.GetString("myValue"));
        }
        #endregion
    }
}