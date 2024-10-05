using API.Data;
using API.IRepositories;
using DataProcessing.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class CartDetailRepos : ICartDetailRepos
    {
        private readonly ApplicationDbContext _context;
        public CartDetailRepos(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Create(CartDetail cartDetail)
        {
            if (await GetCartDetailById(cartDetail.Id) != null)
                throw new DuplicateWaitObjectException("This cart detail already exists!");
            await _context.CartDetails.AddAsync(cartDetail);
        }

        public async Task Delete(Guid id)
        {
            var cartDetail = GetCartDetailById(id).Result;
            if (cartDetail == null)
                throw new KeyNotFoundException("This cart detail does not exist!");
            _context.CartDetails.Remove(cartDetail);
        }

        public async Task<List<CartDetail>> GetAllCartDetails()
        {
            return await _context.CartDetails
                .Include(cd => cd.Cart)
                .Include(cd => cd.ProductDetail)
                .ToListAsync();
        }

        public async Task<CartDetail> GetCartDetailById(Guid id)
        {
            return await _context.CartDetails
                .Include(cd => cd.Cart)
                .Include(cd => cd.ProductDetail)
                .FirstOrDefaultAsync(cd => cd.Id == id);
        }

        public async Task<List<CartDetail>> GetCartDetailsByCartId(Guid cartId)
        {
            var data = await _context.CartDetails.Where(o => o.CartId == cartId)
                .Include(o => o.Cart)
                .ToListAsync();
            return data;
        }
        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
        public async Task Update(CartDetail cartDetail)
        {
            var existingCartDetail = await GetCartDetailById(cartDetail.Id);
            if (existingCartDetail == null)
                throw new KeyNotFoundException("This cart detail does not exist!");

            _context.Entry(cartDetail).State = EntityState.Modified;
        }
    }
}
