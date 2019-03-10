namespace AspNetMvc5Examples.Web.Controllers
{
    //TODO public class MyAccountController : Controller
    //{
    //    private readonly ApplicationDbContext context;

    //    public MyAccountController(ApplicationDbContext context)
    //    {
    //        this.context = context;
    //    }

    //    public ActionResult Register()
    //    {
    //        var model = new MyAspNetUser();
    //        return View(model);
    //    }

    //    [HttpPost]
    //    public ActionResult Register(MyAspNetUser user)
    //    {
    //        if(this.context.MyAspNetUsers.Any(x => x.UserName == user.UserName))
    //        {
    //            this.ModelState.AddModelError(nameof(MyAspNetUser.UserName), $"Name {user.UserName} is already taken.");
    //        }

    //        if (this.ModelState.IsValid)
    //        {
    //            this.context.MyAspNetUsers.Add(user); // TODO save only password hash
    //            this.context.SaveChanges();

    //            this.SetAuthCookie(user);
    //            return this.RedirectToAction("Index", "Home");
    //        }

    //        return View(user);
    //    }

    //    // GET: MyAccountController
    //    public ActionResult Login()
    //    {
    //        var model = new MyAspNetUser();
    //        return View(model);
    //    }

    //    [HttpPost]
    //    public ActionResult Login(MyAspNetUser user)
    //    {
    //        var dbUser = this.context.MyAspNetUsers.FirstOrDefault(x => x.UserName == user.UserName);
    //        if (dbUser == null)
    //        {
    //            this.ModelState.AddModelError(nameof(MyAspNetUser.UserName), $"User with name {user.UserName} does not exists in the DB");
    //        }

    //        if (dbUser.Password != user.Password)
    //        {
    //            this.ModelState.AddModelError(nameof(MyAspNetUser.Password), $"Wrong password");
    //        }

    //        if (this.ModelState.IsValid)
    //        {
    //            this.SetAuthCookie(user);
    //            return this.RedirectToAction("Index", "Home");
    //        }

    //        return View(user);
    //    }

    //    public ActionResult Logout()
    //    {
    //        this.SignOut();
    //        return RedirectToAction("Index");
    //    }

    //    private void SetAuthCookie(MyAspNetUser user)
    //    {
    //        // Real implementation is FormsAuthentication.SetAuthCookie();
    //        // GetAuthCookie: https://github.com/Microsoft/referencesource/blob/master/System.Web/Security/FormsAuthentication.cs

    //        HttpCookie cookie = new HttpCookie(MyOwinMiddleware.AuthenticationKey);
    //        cookie.Value = $"{user.UserName}:{user.Password}";
    //        cookie.Expires = DateTime.Now.AddDays(1);

    //        this.HttpContext.Response.Cookies.Add(cookie);
    //    }

    //    private void SignOut()
    //    {
    //        // FormsAuthentication.SignOut();
    //        this.HttpContext.Response.Cookies.Remove(MyOwinMiddleware.AuthenticationKey);
    //    }
    //}
}