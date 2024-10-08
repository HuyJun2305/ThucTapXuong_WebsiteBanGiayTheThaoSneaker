using Data.Models;
using DataProcessing.Models;

namespace View.IServices
{
    public interface IPromotionServices
    {
        Task<List<Promotion>> GetAllPromotion();
        Task<Promotion> GetPromotionById(Guid? id);
        Task Create(Promotion promotion);
        Task Update(Promotion promotion);
        Task Delete(Guid id);
    }
    public interface IProductDetailPromotionServices
    {
        Task<ProductDetailPromotion> GetByIdAsync(Guid? id);
        Task<IEnumerable<ProductDetailPromotion>?> GetAllAsync();
        Task AddAsync(ProductDetailPromotion productDetailPromotion);
        Task UpdateAsync(ProductDetailPromotion productDetailPromotion);
        Task DeleteAsync(Guid? id);
    }
}
