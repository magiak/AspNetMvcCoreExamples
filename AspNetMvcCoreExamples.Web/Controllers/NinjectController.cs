namespace AspNetMvc5Examples.Web.Controllers
{
    // TODO public class NinjectController : Controller
    //{
    //    private readonly ILoggingService loggingService;
    //    private readonly ApplicationDbContext applicationDbContext;

    //    [Inject]
    //    public ILoggingService LoggingService { get; set; }


    //    public NinjectController(ILoggingService loggingService, ApplicationDbContext dbcontext)
    //    {
    //        this.loggingService = loggingService;
    //        this.applicationDbContext = dbcontext;
    //    }

    //    // GET: Ninject
    //    public ActionResult Index()
    //    {
    //        this.loggingService.Log("Hello from ninject index");
    //        this.LoggingService.Log("Hello from ninject index2");

    //        return this.View();
    //    }

    //    public ActionResult IndexWithoutDI()
    //    {
    //        using(var dbContext = new ApplicationDbContext())
    //        {
    //            var service = new DatabaseLoggingService(dbContext);
    //            service.Log("My log");
    //        }

    //        return this.View();
    //    }
    //}
}