using DataProcessing.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using View.IServices;

namespace View.Controllers
{
    public class ProductDetailsController : Controller
    {
        private readonly IProductServices _productServices;
        private readonly ISoleServices _soleServices;
        private readonly ICategoryServices _categoryServices;
        private readonly IBrandServices _brandServices;
        private readonly IMaterialServices _materialServices;
        private readonly IProductDetailService _productDetailService;
        private readonly ISizeServices _sizeServices;
        private readonly IColorServices _colorServices;


        // GET: ProductDetailsController
        public async Task<IActionResult> Index()
        {
            var viewContext = _productDetailService.GetAllProductDetail().Result;
            if (viewContext == null) return View("'ProductDetail is null!'");
            return View(viewContext.ToList());
        }

        // GET: ProductDetailsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductDetailsController/Create
        public ActionResult Create()
        {
            ViewData["BrandId"] = new SelectList(_brandServices.GetAllBrands().Result.Where(x => x.Status == true), "Id", "Name");
            ViewData["CategoryId"] = new SelectList(_categoryServices.GetAllCategories().Result.Where(x => x.Status == true), "Id", "Name");
            ViewData["MaterialId"] = new SelectList(_materialServices.GetAllMaterials().Result.Where(x => x.Status == true), "Id", "Name");
            ViewData["SoleId"] = new SelectList(_soleServices.GetAllSoles().Result.Where(x => x.Status == true), "Id", "TypeName");
            ViewData["SizeId"] = new SelectList(_sizeServices.GetAllSizes().Result.Where(x => x.Status == true), "Id", "Value");
            ViewData["ColorId"] = new SelectList(_colorServices.GetAllColors().Result.Where(x => x.Status == true), "Id", "HEX");
            return View();
        }

        // POST: ProductDetailsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Price,Stock,Weight,PromotionId,CategoryId,SoleId,BrandId,MaterialId,SizeId,ColorId")] ProductDetail productDetail)
        {
            if (productDetail != null)
            {
                await _productDetailService.Create(productDetail);
                return RedirectToAction(nameof(Index));
            }
            ViewData["BrandId"] = new SelectList(_brandServices.GetAllBrands().Result.Where(x => x.Status == true), "Id", "Name");
            ViewData["CategoryId"] = new SelectList(_categoryServices.GetAllCategories().Result.Where(x => x.Status == true), "Id", "Name");
            ViewData["MaterialId"] = new SelectList(_materialServices.GetAllMaterials().Result.Where(x => x.Status == true), "Id", "Name");
            ViewData["SoleId"] = new SelectList(_soleServices.GetAllSoles().Result.Where(x => x.Status == true), "Id", "TypeName");
            ViewData["SizeId"] = new SelectList(_sizeServices.GetAllSizes().Result.Where(x => x.Status == true), "Id", "Value");
            ViewData["ColorId"] = new SelectList(_colorServices.GetAllColors().Result.Where(x => x.Status == true), "Id", "HEX");
            return View(productDetail);

        }

        // GET: ProductDetailsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductDetailsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductDetailsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductDetailsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
