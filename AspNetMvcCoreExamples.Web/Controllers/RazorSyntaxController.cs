﻿using Microsoft.AspNetCore.Mvc;

namespace AspNetMvc5Examples.Web.Controllers
{
    public class RazorSyntaxController : Controller
    {
        // GET: RazorSyntax
        public IActionResult Examples()
        {
            return this.View();
        }

        // GET: Lab
        public IActionResult Lab()
        {
            return this.View();
        }
    }
}