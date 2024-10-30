using API.Data;
using API.DTO;
using API.IRepositories;
using Data.ViewModels;
using DataProcessing.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailController : ControllerBase
    {
        private readonly IProductDetailRepos _productDetailRepos;

        public ProductDetailController(IProductDetailRepos productDetailRepos)
        {
            _productDetailRepos = productDetailRepos;
        }

        [HttpGet("filterAndsearch")]
        public async Task<ActionResult<List<ProductDetail>>> FilterProductDetails(string? searchQuery = null,
            Guid? colorId = null,
        Guid? sizeId = null,
        Guid? categoryId = null,
        Guid? brandId = null,
        Guid? soleId = null,
        Guid? materialId = null
            )
        {
            var productDetails = await _productDetailRepos.GetFilteredProductDetails( searchQuery,
                        colorId, sizeId, categoryId, brandId, soleId, materialId);

            // Kiểm tra xem có sản phẩm nào được tìm thấy không
            if (productDetails == null || productDetails.Count == 0)
            {
                return NotFound(); // Trả về 404 nếu không có sản phẩm nào
            }

            return Ok(productDetails); // Trả về danh sách sản phẩm
            }




            // GET: api/ProductDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDetail>>> GetProductDetails()
        {
            return await _productDetailRepos.GetAllProductDetail();
        }

        // GET: api/ProductDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDetail>> GetProductDetailById(string id)
        {
            return await _productDetailRepos.GetProductDetailById(id);
        }


        [HttpGet("productid{id}")]
        public async Task<ActionResult<List<ProductDetail>>> GetProductDetailByProductId(Guid id)
        {
            return await _productDetailRepos.GetAllProductDetailByProductId(id);
        }




        // PUT: api/ProductDetail/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductDetail(string id, ProductDetail productDetail)
        {
            try
            {
                await _productDetailRepos.Update(productDetail);
                await _productDetailRepos.SaveChanges();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }

            return NoContent();
        }

        // POST: api/ProductDetail
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductDetail>> PostProductDetail(ProductDetail productDetail)
        {
            try
            {
                await _productDetailRepos.Create(productDetail);
                await _productDetailRepos.SaveChanges();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }

            return CreatedAtAction("GetProductDetails", new { id = productDetail.Id }, productDetail);
        }

        


        // DELETE: api/ProductDetail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductDetail(string id)
        {
            try
            {
                await _productDetailRepos.Delete(id);
                await _productDetailRepos.SaveChanges();
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
            return NoContent();
        }

        [HttpPost("GetProductVariants")]
        public async Task<IActionResult> GetProductVariants([FromBody] List<Guid> selectedProductIds)
        {
            if (selectedProductIds == null || !selectedProductIds.Any())
            {
                return BadRequest("No products selected.");
            }

            try
            {
                // Gọi service để lấy danh sách biến thể dựa trên danh sách ProductIds
                var productVariants = await _productDetailRepos.GetVariantsByProductIds(selectedProductIds);

                // Nếu không có biến thể nào
                if (productVariants == null || !productVariants.Any())
                {
                    return NotFound("No variants found for the selected products.");
                }

                // Trả về danh sách biến thể dưới dạng JSON
                return Ok(productVariants);
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu có lỗi xảy ra
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}

