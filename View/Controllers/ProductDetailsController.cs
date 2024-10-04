using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataProcessing.Models;
using View.Data;
using View.IServices;
using View.Servicecs;

namespace View.Controllers
{
    public class ProductDetailsController : Controller
    {
        private readonly IProductDetailService _productDetailService;
        private readonly ISizeServices _sizeServices;
        private readonly IColorServices _colorServices;
        private readonly IProductServices _productServices;

        public ProductDetailsController(IProductDetailService productDetailService, ISizeServices sizeServices, IColorServices colorServices, IProductServices productServices)
        {
            _productDetailService = productDetailService;
            _sizeServices = sizeServices;
            _colorServices = colorServices;
            _productServices = productServices;
           
        }

        // GET: ProductDetails
        public async Task<IActionResult> Index()
        {
            var viewContext = _productDetailService.GetAllProductDetail().Result;
            return View(viewContext.ToList());
        }

        // GET: ProductDetails/Details/5
        public async Task<IActionResult> Details(string id)
        {
            var product = _productDetailService.GetProductDetailById(id).Result;
            return View(product);
        }

        // GET: ProductDetails/Create
        public IActionResult Create()
        {
            ViewData["ColorId"] = new SelectList(_colorServices.GetAllColors().Result.Where(x => x.Status), "Id", "Name"); ;
            ViewData["SizeId"] = new SelectList(_sizeServices.GetAllSizes().Result.Where(x => x.Status), "Id", "Value");
            ViewData["ProductId"] = new SelectList(_productServices.GetAllProducts().Result, "Id", "Name");
            return View();
        }

        // POST: ProductDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Price,Stock,Weight,ProductId,ColorId,SizeId")] ProductDetail productDetail)
        {
            if (productDetail.ProductId != null)
            {
                 await _productDetailService.Create(productDetail);
                return RedirectToAction(nameof(Index));
            }
            ViewData["ColorId"] = new SelectList(_colorServices.GetAllColors().Result.Where(x => x.Status), "Id", "Name"); ;
            ViewData["SizeId"] = new SelectList(_sizeServices.GetAllSizes().Result.Where(x => x.Status), "Id", "Value");
            ViewData["ProductId"] = new SelectList(_productServices.GetAllProducts().Result, "Id", "Name");
            return View(productDetail);
        }

        // GET: ProductDetails/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (_productDetailService.GetAllProductDetail() == null)
            {
                return NotFound();
            }

            var product = await _productDetailService.GetProductDetailById(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["ColorId"] = new SelectList(_colorServices.GetAllColors().Result.Where(x => x.Status), "Id", "Name"); ;
            ViewData["SizeId"] = new SelectList(_sizeServices.GetAllSizes().Result.Where(x => x.Status), "Id", "Value");
            ViewData["ProductId"] = new SelectList(_productServices.GetAllProducts().Result, "Id", "Name");
            return View(product);
        }

        // POST: ProductDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Price,Stock,Weight,ProductId,ColorId,SizeId")] ProductDetail productDetail)
        {
            if (id != productDetail.Id)
            {
                return NotFound();
            }

            if (productDetail.Id != null)
            {
                try
                {
                    await _productDetailService.Update(productDetail);
                }
                catch (Exception ex)
                {
                    return Content(ex.Message);
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ColorId"] = new SelectList(_colorServices.GetAllColors().Result.Where(x => x.Status), "Id", "Name"); ;
            ViewData["SizeId"] = new SelectList(_sizeServices.GetAllSizes().Result.Where(x => x.Status), "Id", "Value");
            ViewData["ProductId"] = new SelectList(_productServices.GetAllProducts().Result, "Id", "Name");
            return View(productDetail);
        }

        // GET: ProductDetails/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (_productDetailService.GetAllProductDetail() == null)
            {
                return NotFound();
            }

            var product = await _productDetailService.GetProductDetailById(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }


        // POST: ProductDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_productDetailService.GetAllProductDetail() == null)
            {
                return Problem("Entity set 'ProductDetail'  is null.");
            }
            await _productDetailService.Delete(id);

            return RedirectToAction(nameof(Index));
        }

    }

}


