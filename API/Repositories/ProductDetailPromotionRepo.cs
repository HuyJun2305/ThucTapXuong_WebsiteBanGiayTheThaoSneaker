using API.Data;
using API.IRepositories;
using Data.Models;
using DataProcessing.Models;
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

        public async  Task AddAsync(ProductDetailPromotion productDetailPromotion)
        {
            if (await GetByIdAsync(productDetailPromotion.Id) != null) throw new DuplicateWaitObjectException($"productDetailPromotion : {productDetailPromotion.Id} is existed!");
            await _context.ProductDetailPromotions.AddAsync(productDetailPromotion);
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductDetailPromotion>> GetAllAsync()
        {
            return await _context.ProductDetailPromotions.ToListAsync();
        }

        public async Task<ProductDetailPromotion> GetByIdAsync(Guid id)
        {
           return await _context.ProductDetailPromotions.FindAsync(id);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ProductDetailPromotion productDetailPromotion)
        {
            if (await GetByIdAsync(productDetailPromotion.Id) == null) throw new KeyNotFoundException("Not found this Id!");
            _context.Entry(productDetailPromotion).State = EntityState.Modified;
        }
    }
}
