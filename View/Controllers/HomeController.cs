using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using View.IServices;
using View.Models;
using View.Servicecs;

namespace View.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductServices _productServices;
        private readonly ISizeServices _sizeServices;
        private readonly IColorServices _colorServices;
        private readonly ICategoryServices _categoryServices;


        public HomeController(IProductServices productServices, ISizeServices sizeServices,
            IColorServices colorServices,
            ICategoryServices categoryServices)
        {
            _productServices = productServices;
            _sizeServices = sizeServices;
            _colorServices = colorServices;
            _categoryServices = categoryServices;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["ColorId"] = new SelectList((await _colorServices.GetAllColors()).Where(x => x.Status), "Id", "HEX");
            ViewData["SizeId"] = new SelectList((await _sizeServices.GetAllSizes()).Where(x => x.Status), "Id", "Value");
            ViewData["ProductId"] = new SelectList(await _productServices.GetAllProducts(), "Id", "Name");
            ViewData["CategoryId"] = new SelectList(_categoryServices.GetAllCategories().Result.Where(x => x.Status), "Id", "Name");

            var viewContext = _productServices.GetAllProducts().Result;
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
