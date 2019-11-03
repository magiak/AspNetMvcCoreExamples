using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetMvcCoreExamples.Web.Data;
using Microsoft.AspNetCore.Mvc;

namespace AspNetMvcCoreExamples.Web.Controllers
{
    public class DependencyInjectionController : Controller
    {
        public IActionResult Index([FromServices]ApplicationDbContext dbContext)
        {
            return Content(dbContext.Users.First().UserName);
        }
    }
}