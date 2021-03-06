﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetMvcCoreExamples.Web.Models;

namespace AspNetMvcCoreExamples.Web.Controllers
{
    //public class HomeController
    //{
    //    public IActionResult Index() => new ViewResult();
    //}

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var value = this.HttpContext.Items["myMiddlewareKey"];

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
