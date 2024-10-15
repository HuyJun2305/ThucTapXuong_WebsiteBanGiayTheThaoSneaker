using Microsoft.AspNetCore.Mvc;

namespace View.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            // Kiểm tra xem session có tồn tại không
            var token = HttpContext.Session.GetString("AuthToken");
            if (string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }
    }
}
