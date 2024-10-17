using Microsoft.AspNetCore.Mvc;

namespace View.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
