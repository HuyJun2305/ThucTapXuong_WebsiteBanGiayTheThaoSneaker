using DataProcessing.Models;

namespace View.IServices
{
    public interface IProductDetailService
    {
        Task<IEnumerable<ProductDetail>> GetAllProductDetail();
        Task<ProductDetail> GetProductDetailById(string id);
        Task Create(ProductDetail productDetail);
        Task Update(ProductDetail productDetail);
        Task Delete(string id);

        Task<IEnumerable<ProductDetail>?> SearchProductDetails(string searchString);
        Task<IEnumerable<ProductDetail>?> FilterProductDetails(Guid? selectedColorId, Guid? selectedCategoryId,
            Guid? selectedBrandId, Guid? selectedSoleId, Guid? selectedSizeId);
    }
}
