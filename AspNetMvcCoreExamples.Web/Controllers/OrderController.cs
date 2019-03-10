namespace AspNetMvc5Examples.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class OrderController : Controller
    {
        // GET: Order
        public IActionResult Details(int userId, int orderId)
        {
            return this.Content($"UserId={userId} OrderId={orderId}");
        }
    }
}