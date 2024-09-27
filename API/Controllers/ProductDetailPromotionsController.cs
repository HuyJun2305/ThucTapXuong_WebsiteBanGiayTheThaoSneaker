using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.IRepositories;
using Data.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailPromotionsController : ControllerBase
    {
        private readonly IProductDetailPromotion _productDetailPromotionRepository;

        public ProductDetailPromotionsController(IProductDetailPromotion productDetailPromotionRepository)
        {
            _productDetailPromotionRepository = productDetailPromotionRepository;
        }

        // GET: api/ProductDetailPromotions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDetailPromotion>>> GetProductDetailPromotions()
        {
            try
            {
                var promotions = await _productDetailPromotionRepository.GetAllAsync();
                return Ok(promotions);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // GET: api/ProductDetailPromotions/{productDetailId}/{promotionId}
        [HttpGet("{productDetailId}/{promotionId}")]
        public async Task<ActionResult<ProductDetailPromotion>> GetProductDetailPromotion(string productDetailId, Guid promotionId)
        {
            try
            {
                var productDetailPromotion = await _productDetailPromotionRepository.GetByIdAsync(productDetailId, promotionId);
                if (productDetailPromotion == null)
                {
                    return NotFound();
                }

                return Ok(productDetailPromotion);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // PUT: api/ProductDetailPromotions/{productDetailId}/{promotionId}
        [HttpPut("{productDetailId}/{promotionId}")]
        public async Task<IActionResult> PutProductDetailPromotion(string productDetailId, Guid promotionId, ProductDetailPromotion productDetailPromotion)
        {
            if (productDetailId != productDetailPromotion.ProductDetailId || promotionId != productDetailPromotion.PromotionId)
            {
                return BadRequest(new { message = "Product Detail ID or Promotion ID mismatch." });
            }

            try
            {
                await _productDetailPromotionRepository.UpdateAsync(productDetailPromotion);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }

            return NoContent();
        }

        // POST: api/ProductDetailPromotions
        [HttpPost]
        public async Task<ActionResult<ProductDetailPromotion>> PostProductDetailPromotion(ProductDetailPromotion productDetailPromotion)
        {
            try
            {
                await _productDetailPromotionRepository.AddAsync(productDetailPromotion);
                return CreatedAtAction(nameof(GetProductDetailPromotion),
                    new { productDetailId = productDetailPromotion.ProductDetailId, promotionId = productDetailPromotion.PromotionId },
                    productDetailPromotion);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // DELETE: api/ProductDetailPromotions/{productDetailId}/{promotionId}
        [HttpDelete("{productDetailId}/{promotionId}")]
        public async Task<IActionResult> DeleteProductDetailPromotion(string productDetailId, Guid promotionId)
        {
            try
            {
                await _productDetailPromotionRepository.DeleteAsync(productDetailId, promotionId);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
