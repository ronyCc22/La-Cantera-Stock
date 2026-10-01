using Microsoft.AspNetCore.Mvc;

namespace LaCanteraStock.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
