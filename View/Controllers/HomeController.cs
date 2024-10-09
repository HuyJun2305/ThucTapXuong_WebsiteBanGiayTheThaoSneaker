using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using View.IServices;
using View.Models;

namespace View.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductServices productServices;

        public HomeController(IProductServices _productServices)
        {
            productServices = _productServices;
        }

        public async Task<IActionResult> Index()
        {
            var viewContext = productServices.GetAllProducts().Result;
            if (viewContext == null) return View("'Product is null!'");
            return View(viewContext.ToList());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
