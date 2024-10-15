using API.Data;
using API.IRepositories;
using DataProcessing.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class CartRepo : ICartRepo
    {
        private readonly ApplicationDbContext _context;

        public CartRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Create(Cart cart)
        {
            await  _context.Carts.AddAsync(cart);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var deleteItem = await _context.Carts.FindAsync(id);
            _context.Carts.Remove(deleteItem);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Cart>> GetAllCart()
        {
            var lstCart = await _context.Carts.ToListAsync();
            return lstCart;
        }

        public async Task<Cart> GetById(Guid id)
        {
            var item = await _context.Carts.FindAsync(id);
            return item;
        }

        public async Task Update(Guid id, Cart cart)
        {
            var updateItem = await _context.Carts.FindAsync(id);
            _context.Carts.Update(updateItem);
            await _context.SaveChangesAsync();      
        }
    }
}
