using DataProcessing.Models;

namespace API.IRepositories
{
    public interface IProductDetailRepos
    {
        Task<List<ProductDetail>> GetAllProductDetail();
        Task<ProductDetail> GetProductDetailById(Guid id);
        Task Create(ProductDetail productDetail);
        Task Update(ProductDetail productDetail);
        Task Delete(Guid id);

        Task SaveChanges();
    }
}
