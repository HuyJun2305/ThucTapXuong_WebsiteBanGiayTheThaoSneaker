using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.DTO;
using API.Data;
using DataProcessing.Models;
using API.IRepositories;
using API.Repositories;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailController : ControllerBase
    {
        private readonly IProductDetailRepos _productDetailRepos;
        private readonly ApplicationDbContext _context;

        public ProductDetailController (IProductDetailRepos productDetailRepos, ApplicationDbContext context)
        {
            _productDetailRepos = productDetailRepos;
            _context = context;
        }

        // GET: api/ProductDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDetail>>> GetProductDetailsDTO()
        {
                return await  _productDetailRepos.GetAllProductDetail();
        }

        // GET: api/ProductDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDetail>> GetProductDetail(string id)
        {
                return await _productDetailRepos.GetProductDetailById(id);  
        }

        // PUT: api/ProductDetail/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductDetail(string id, ProductDetailDTO productDetailDTO)
        {
            try
            {
                ProductDetail productDetail = new ProductDetail()
                {
                    Id = productDetailDTO.Id,
                    Price = productDetailDTO.Price,
                    Stock = productDetailDTO.Stock,
                    Weight = productDetailDTO.Weight,

                    ProductId = productDetailDTO.ProductId,
                    ColorId = productDetailDTO.ColorId,
                    SizeId = productDetailDTO.SizeId

                };
                await _productDetailRepos.Update(productDetail);
                await _productDetailRepos.SaveChanges();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }

            return CreatedAtAction("GetProductDetail", new { id = productDetailDTO.Id }, productDetailDTO);
        }

        // POST: api/ProductDetail
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductDetailDTO>> PostProductDetail(ProductDetailDTO productDetailDTO)
        {
            try
            {
                // Lấy thông tin sản phẩm từ context, bao gồm thông tin thương hiệu
                var product = await _context.Products
                    .Include(p => p.Brand) // Bao gồm thông tin thương hiệu
                    .FirstOrDefaultAsync(p => p.Id == productDetailDTO.ProductId);

                if (product == null)
                {
                    return NotFound($"Product with ID {productDetailDTO.ProductId} not found.");
                }

                // Lấy thông tin màu sắc từ context
                var color = await _context.Colors.FindAsync(productDetailDTO.ColorId);
                if (color == null)
                {
                    return NotFound($"Color with ID {productDetailDTO.ColorId} not found.");
                }

                // Lấy thông tin kích cỡ từ context (Size là kiểu int)
                var size = await _context.Sizes.FindAsync(productDetailDTO.SizeId);
                if (size == null)
                {
                    return NotFound($"Size with ID {productDetailDTO.SizeId} not found.");
                }

                // Ép kiểu giá trị size về string
                string sizeValue = size.Value.ToString(); // Hoặc bạn có thể sử dụng size.Value.ToString() nếu size là Nullable<int>

                // Tạo Id theo định dạng "chữ cái đầu tiên của Brand - chữ cái đầu tiên của Product - chữ cái đầu tiên của Color - kích cỡ"
                string baseId = $"{GetFirstChar(product.Brand.Name)}{GetFirstChar(product.Name)}{GetFirstChar(color.Name)}{sizeValue}";

                // Lấy số lượng bản ghi hiện tại để tạo số tự sinh
                int count = await _context.ProductDetails
                    .CountAsync(pd => pd.Id.StartsWith(baseId)); // Đếm số bản ghi có cùng tiền tố Id

                // Tạo Id hoàn chỉnh với số tự sinh (bắt đầu từ 1)
                string productDetailId = $"{baseId}0{count + 1}";

                ProductDetail productDetail = new ProductDetail()
                {
                    Id = productDetailId, // Sử dụng Id đã cấu hình
                    Price = productDetailDTO.Price,
                    Stock = productDetailDTO.Stock,
                    Weight = productDetailDTO.Weight,
                    ProductId = productDetailDTO.ProductId,
                    ColorId = productDetailDTO.ColorId,
                    SizeId = productDetailDTO.SizeId // SizeId là kiểu int, vẫn được lưu
                };

                await _productDetailRepos.Create(productDetail);
                await _productDetailRepos.SaveChanges();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }

            return CreatedAtAction("GetProductDetail", new { id = productDetailDTO.ProductId }, productDetailDTO);
        }

        // Hàm để lấy 2 ký tự đầu tiên
        private string GetFirstChar(string value)
        {
            return !string.IsNullOrEmpty(value) ? value.Substring(0, 1).ToUpper() : string.Empty; // Lấy chữ cái đầu tiên và chuyển thành chữ hoa
        }


        // DELETE: api/ProductDetail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductDetail(string id)
        {
            try
            {
                await _productDetailRepos.Delete(id);
                _productDetailRepos.SaveChanges();
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
            return NoContent();
        }


    }
}
