using API.Data;
using API.IRepositories;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class ProductDetailPromotionRepo : IProductDetailPromotionRepos
    {
        private readonly ApplicationDbContext _context;

        public ProductDetailPromotionRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task  AddAsync(ProductDetailPromotion productDetailPromotion)
        {
            await _context.ProductDetailPromotions.AddAsync(productDetailPromotion);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string productDetailId, Guid promotionId)
        {
            var productDetailPromotion = await GetByIdAsync(productDetailId, promotionId);
            if (productDetailPromotion != null)
            {
                _context.ProductDetailPromotions.Remove(productDetailPromotion);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ProductDetailPromotion>> GetAllAsync()
        {
            return await _context.ProductDetailPromotions
           .Include(pd => pd.ProductDetail)
           .Include(pd => pd.Promotion)
           .ToListAsync();
        }

        public async Task<ProductDetailPromotion> GetByIdAsync(string productDetailId, Guid promotionId)
        {
            return await _context.ProductDetailPromotions
              .Include(pd => pd.ProductDetail)
              .Include(pd => pd.Promotion)
              .FirstOrDefaultAsync(pd => pd.ProductDetailId == productDetailId && pd.PromotionId == promotionId);
        }

        public async Task UpdateAsync(ProductDetailPromotion productDetailPromotion)
        {
            _context.ProductDetailPromotions.Update(productDetailPromotion);
            await _context.SaveChangesAsync();
        }
    }
}
