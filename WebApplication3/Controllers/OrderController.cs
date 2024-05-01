using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
