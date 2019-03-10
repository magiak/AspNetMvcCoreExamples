using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace AspNetMvc5Examples.Web.Controllers
{
    public class CookieAndSessionController : Controller
    {
        private const string Key = "my-key";

        // cookie = per user on the client
        public ActionResult SaveCookie()
        {
            var cookieOptions = new CookieOptions()
            {
                Expires = DateTime.Now.AddMinutes(5)
            };

            this.HttpContext.Response.Cookies.Append(Key, "Hello from Cookie", cookieOptions);
            return this.Content("Cookie Saved");
        }

        public ActionResult GetCookie()
        {
            return this.Content(this.HttpContext.Request.Cookies[Key]);
        }

        // Session = per user on the server
        public ActionResult SaveSession()
        {
            this.HttpContext.Session.SetString(Key, "Hello from Session");
            return this.Content("Session Saved");
        }

        public ActionResult GetSession()
        {
            return this.Content(this.HttpContext.Session.GetString(Key));
        }

        // Cache is shared between users and can be expired
        //public ActionResult SaveCache()
        //{
        //    this.HttpContext.Cache[Key] = "Hello from Cache";
        //    return this.Content("Cache Saved");
        //}

        //public ActionResult GetCache()
        //{
        //    return this.Content(this.HttpContext.Cache[Key].ToString());
        //}

        // TODO SINGLETON Application is shared between users and can NOT be expired 
        //public ActionResult SaveApplication()
        //{
        //    this.HttpContext.Application[Key] = "Hello from Application";
        //    return this.Content("Application Saved");
        //}

        //public ActionResult GetApplication()
        //{
        //    return this.Content(this.HttpContext.Application[Key].ToString());
        //}
    }
}