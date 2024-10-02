using DataProcessing.Models;

namespace API.IRepositories
{
    public interface IProductDetailRepos
    {
        Task<List<ProductDetail>> GetAllProductDetail();
        Task<ProductDetail> GetProductDetailById(string id);
        Task Create(ProductDetail productDetail);
        Task Update(ProductDetail productDetail);
        Task Delete(string id);

        Task SaveChanges();


    }
}
