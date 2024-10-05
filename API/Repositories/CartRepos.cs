using API.Data;
using API.IRepositories;
using DataProcessing.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class CartRepos : ICartRepos
    {
        private readonly ApplicationDbContext _context;
        public CartRepos(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Create(Cart cart)
        {
            if (await GetCartById(cart.Id) != null)
                throw new DuplicateWaitObjectException("This cart already exists!");

            await _context.Carts.AddAsync(cart);
        }

        public async Task Delete(Guid id)
        {
            var cart = GetCartById(id).Result;
            if (cart == null)
                throw new KeyNotFoundException("This cart does not exist!");

            _context.Carts.Remove(cart);
        }

        public async Task<List<Cart>> GetAllCarts()
        {
            return await _context.Carts
            .Include(c => c.Account)
            .ToListAsync();
        }

        public async Task<Cart> GetCartById(Guid id)
        {
            return await _context.Carts
            .Include(c => c.Account)
            .FirstOrDefaultAsync(c => c.Id == id);
        }
        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
        public async Task Update(Cart cart)
        {
            var existingCart = await GetCartById(cart.Id);
            if (existingCart == null)
                throw new KeyNotFoundException("This cart does not exist!");

            _context.Entry(cart).State = EntityState.Modified;
        }
    }
}
