using DataProcessing.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using View.IServices;
using View.Servicecs;
using View.ViewModel;

namespace View.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IProductDetailService _productDetailService;
        private readonly ISizeServices _sizeServices;
        private readonly IColorServices _colorServices;
        private readonly IProductServices _productServices;
        private readonly ICategoryServices _categoryServices;
        private readonly ISoleServices _soleServices;
        private readonly IBrandServices _brandServices;
        private readonly IMaterialServices _materialServices;
        private readonly ISelectedImageServices _selectedImageServices;


        public CustomerController(IProductDetailService productDetailService,
            ISizeServices sizeServices, IColorServices colorServices,
            IProductServices productServices, ICategoryServices categoryServices,
            ISoleServices soleServices, IBrandServices brandServices,
            IMaterialServices materialServices, ISelectedImageServices selectedImageServices)
        {
            _productDetailService = productDetailService;
            _sizeServices = sizeServices;
            _colorServices = colorServices;
            _productServices = productServices;
            _brandServices = brandServices;
            _categoryServices = categoryServices;
            _soleServices = soleServices;
            _materialServices = materialServices;
            _selectedImageServices = selectedImageServices;
        }
        public IActionResult Index()
        {
            var products = _productServices.GetAllProducts().Result;
            var selectedImages = _selectedImageServices.GetAllSelectedImages().Result;
            var productDetails = _productDetailService.GetAllProductDetail().Result;
            if (products == null) return View("'Product is null!'");
            var productIndexData = new ProductDetailIndexDetailsVM()
            {
                Products = products,
                ImagesForProduct = selectedImages,
                ProductDetails = productDetails
               
            };
            return View(productIndexData);
        }

        public IActionResult Details(Guid id)
        {
            // Lấy tất cả dữ liệu sản phẩm, hình ảnh và chi tiết sản phẩm
            var products = _productServices.GetAllProducts().Result;
            var selectedImages = _selectedImageServices.GetAllSelectedImages().Result;
            var productDetails = _productDetailService.GetAllProductDetail().Result;

            // Tìm sản phẩm với id tương ứng
            var selectedProduct = products.FirstOrDefault(p => p.Id == id);
            if (selectedProduct == null) return NotFound("Product not found!");

            // Lọc hình ảnh và chi tiết sản phẩm liên quan đến sản phẩm được chọn
            var relatedImages = selectedImages.Where(i => i.ProductId == id).ToList();
            var relatedProductDetails = productDetails.Where(d => d.ProductId == id).ToList();

            // Tạo ViewModel chỉ với dữ liệu của sản phẩm được chọn
            var productDetailData = new ProductDetailIndexDetailsVM
            {
                Products = new List<Product> { selectedProduct },
                ImagesForProduct = relatedImages,
                ProductDetails = relatedProductDetails
            };

            return View(productDetailData); // Hiển thị View với dữ liệu chi tiết của sản phẩm
        }


        public async Task<IActionResult> ViewProductAsync() 
        {
            ViewData["ColorId"] = new SelectList((await _colorServices.GetAllColors()).Where(x => x.Status), "Id", "Name");
            ViewData["SizeId"] = new SelectList((await _sizeServices.GetAllSizes()).Where(x => x.Status), "Id", "Value");
            ViewData["ProductId"] = new SelectList(await _productServices.GetAllProducts(), "Id", "Name");
            ViewData["BrandId"] = new SelectList(await _brandServices.GetAllBrands(), "Id", "Name");
            ViewData["CategoryId"] = new SelectList(await _categoryServices.GetAllCategories(), "Id", "Name");
            ViewData["SoleId"] = new SelectList(await _soleServices.GetAllSoles(), "Id", "TypeName");
            ViewData["MaterialId"] = new SelectList(await _materialServices.GetAllMaterials(), "Id", "Name");

            // Lấy dữ liệu productDetail
            var viewContext = await _productDetailService.GetAllProductDetail();

            // Kiểm tra xem dữ liệu có hợp lệ không (loại bỏ null hoặc kiểm tra dữ liệu)
            if (viewContext == null || !viewContext.Any())
            {
                // Nếu không có dữ liệu hoặc null, trả về một thông báo cho view
                ViewBag.Message = "No product details found.";
                return View(new List<ProductDetail>()); // Trả về một danh sách rỗng
            }

            // Trả về view với dữ liệu hợp lệ
            return View(viewContext);
        }

    }
}
