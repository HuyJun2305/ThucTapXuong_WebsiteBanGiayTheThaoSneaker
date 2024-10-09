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
        private readonly ApplicationDbContext _context;

        public ProductDetailController(IProductDetailRepos productDetailRepos, ApplicationDbContext context)
        {
            _productDetailRepos = productDetailRepos;
            _context = context;
        }

        //[HttpGet("search")]
        //public async Task<IActionResult> SearchProductDetails(string? searchString, List<ProductDetail> productDetails)
        //{
        //    var products = _context.ProductDetails
        //                              .Include(p => p.Color)
        //                              .Include(p => p.Product)
        //                                  .ThenInclude(p => p.Brand)
        //                              .Include(p => p.Product)
        //                                  .ThenInclude(p => p.Category)
        //                              .Include(p => p.Product)
        //                                  .ThenInclude(p => p.Material)
        //                              .Include(p => p.Product)
        //                                  .ThenInclude(p => p.Sole)
        //                              .AsQueryable();
        //    if (!string.IsNullOrEmpty(searchString))
        //    {
        //        products = productDetails.AsQueryable().Where(p =>
        //            p.Product.Name.Contains(searchString) ||       // Tìm theo tên Product
        //            p.Color.Name.Contains(searchString) ||         // Tìm theo Color
        //            p.Product.Brand.Name.Contains(searchString) || // Tìm theo Brand
        //            p.Product.Material.Name.Contains(searchString) ||
        //            p.Product.Sole.TypeName.Contains(searchString) ||
        //            p.Product.Category.Name.Contains(searchString) ||
        //            p.Id.Contains(searchString)
        //        );
        //    }


        //    return Ok(await products.ToListAsync());
        //}
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
        public async Task<ActionResult<IEnumerable<ProductDetail>>> GetProductDetailsDTO()
        {
            return await _productDetailRepos.GetAllProductDetail();
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
                string baseId = $"{(product.Brand.Name)}-{(product.Name)}-{(color.Name)}-{sizeValue}-";

                // Lấy số lượng bản ghi hiện tại để tạo số tự sinh
                int count = await _context.ProductDetails
                    .CountAsync(pd => pd.Id.StartsWith(baseId)); // Đếm số bản ghi có cùng tiền tố Id

                // Tạo Id hoàn chỉnh với số tự sinh (bắt đầu từ 1)
                string productDetailId = $"{baseId}{count + 1}";

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


    }
}
