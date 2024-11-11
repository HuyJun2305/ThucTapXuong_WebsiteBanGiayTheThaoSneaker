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
using View.ViewModel;
using API.DTO;
using Data.Models;
using Data.ViewModels;

namespace View.Controllers
{
    public class PromotionsController : Controller
    {
        private readonly IPromotionServices _PromotionSer;
        private readonly IProductDetailPromotionServices _ProductDetailPromotionSer;
        private readonly IProductDetailService _ProductDetailService;
        private readonly IProductServices _ProductServices;

        public PromotionsController(IPromotionServices promotionSer, IProductDetailPromotionServices productDetailPromotionSer, IProductDetailService productDetailService, IProductServices productServices)
        {
            _PromotionSer = promotionSer;
            _ProductDetailPromotionSer = productDetailPromotionSer;
            _ProductDetailService = productDetailService;
            _ProductServices = productServices;
        }

        // GET: Promotions
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var viewContext = _PromotionSer.GetAllPromotion().Result;
            if (viewContext == null) return View("'Product is null!'");
            return View(viewContext.ToList());
        }

        //  GET: Promotions/Details/5

        public async Task<IActionResult> Details(Guid id)
        {
            var promotion = await _PromotionSer.GetPromotionById(id);
            if (promotion == null)
            {
                return NotFound();
            }
            return View(promotion);
        }

        // GET: Promotions/Create
        public async Task<IActionResult> Create()
        {
            var products = await _ProductServices.GetAllProducts();
            var productList = products.Select(p => new ProductViewModel
            {
                Id = p.Id,
                Name = p.Name
            }).ToList();

            ViewBag.ProductList = new SelectList(productList, "Id", "Name");

            return View();

        }


        // POST: Promotions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,DiscountValue,StartDate,EndDate,Status")] Promotion promotion, string selectedVariantIds)
        {
            if (ModelState.IsValid)
            {   
                try
                {
                    promotion.Id = Guid.NewGuid();
                    await _PromotionSer.Create(promotion);

                    var variantIds = selectedVariantIds.Split(',').ToList();

                    // Kiểm tra xem có biến thể nào được chọn không
                    if (selectedVariantIds != null && selectedVariantIds.Any())
                    {
                        foreach (var productDetailId in variantIds)
                        {
                            var productDetailPrice = await _ProductDetailService.GetProductDetailById(productDetailId);
                            // Tạo mới mối quan hệ giữa biến thể và khuyến mãi
                            var productDetailPromotion = new ProductDetailPromotion
                            {
                                Id = Guid.NewGuid(),
                                ProductDetailId = productDetailId, 
                                PromotionId = promotion.Id, 
                                PriceUpdate = productDetailPrice.Price - productDetailPrice.Price * (promotion.DiscountValue / 100)
                            };

                            await _ProductDetailPromotionSer.AddAsync(productDetailPromotion);
                        }
                    }

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "An error occurred while saving the promotion. Please try again."); 
                }
            }


            return View(promotion);
        }

        // GET: Promotions/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            var products = await _ProductServices.GetAllProducts();
            var productList = products.Select(p => new ProductViewModel
            {
                Id = p.Id,
                Name = p.Name
            }).ToList();

            ViewBag.ProductList = new SelectList(productList, "Id", "Name");




            var promotion = await _PromotionSer.GetPromotionById(id);
            if (promotion == null)
            {
                return NotFound();
            }
            return View(promotion);
        }

        // POST: Promotions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,DiscountValue,StartDate,EndDate,Status")] Promotion promotion)
        {
            if (id != promotion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _PromotionSer.Update(promotion);
                return RedirectToAction(nameof(Index));
            }
            return View(promotion);
        }

        // GET: Promotions/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {


            var promotion = await _PromotionSer.GetPromotionById(id);
            if (promotion == null)
            {
                return NotFound();
            }


            return View(promotion);
        }

        // POST: Promotions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {


            await _PromotionSer.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        //private bool PromotionExists(Guid id)
        //{
        //  return (_context.Promotion?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
        [HttpPost]
        public async Task<IActionResult> GetProductVariants([FromBody] List<Guid> selectedProductIds)
        {
            try
            {
                if (selectedProductIds == null || selectedProductIds.Count == 0)
                {
                    return BadRequest("No product IDs provided.");
                }

                var variants = await _ProductDetailService.GetVariantsByProductIds(selectedProductIds);

                return Json(variants);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }
        // GET: Promotions/ProductDetailsPromotion
        
        public async Task<IActionResult> ProductDetailsPromotion()
        {
            try
            {
                
                var productDetailsPromotion = await _PromotionSer.GetAllProductDetailsPromotion();

               
                return View(productDetailsPromotion);
            }
            catch (Exception ex)
            {
              
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> ToggleStatus(Guid id)
        {
            // Tìm kiếm vật liệu theo ID
            var material = await _PromotionSer.GetPromotionById(id);
            if (material == null)
            {
                return NotFound();
            }

            material.Status = !material.Status;
            await _PromotionSer.Update(material);

            return RedirectToAction("Index");
        }


    }
}
