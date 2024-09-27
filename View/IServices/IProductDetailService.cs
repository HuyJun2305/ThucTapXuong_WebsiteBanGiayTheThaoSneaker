using DataProcessing.Models;

namespace View.IServices
{
    public interface IProductDetailService
    {
        Task<IEnumerable<ProductDetail>> GetAllProductDetail();
        Task<ProductDetail> GetProductDetailById(Guid id);
        Task Create(ProductDetail productDetail);
        Task Update(ProductDetail productDetail);
        Task Delete(Guid id);

    }
}
