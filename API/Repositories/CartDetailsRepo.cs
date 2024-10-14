using API.Data;
using API.IRepositories;
using DataProcessing.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace API.Repositories
{
    public class CartDetailsRepo:ICartDetailsRepo
    {
        private readonly ApplicationDbContext _context;
        public CartDetailsRepo(ApplicationDbContext context)
        {
            _context=context;
        }
        public async Task CreateCartDetails(CartDetail cartDetails)
        { 
            await _context.CartDetails.AddAsync(cartDetails);
            await _context.SaveChangesAsync();
        }
        public async Task<List<CartDetail>> GetCartDetails()
        {
            var cartDetails = await _context.CartDetails.ToListAsync();

            return cartDetails; 
        }
        public async Task<CartDetail> GetCartDetailByIdAsync(Guid id)
        {
            var cartDetails =  _context.CartDetails.Find(id);
            return cartDetails;
        }
        public async Task UpdateCartQuantityAsync(CartDetail cartDetails , Guid cartDetailsId)
        {
            var updateItem = await _context.CartDetails.FindAsync(cartDetailsId);
            if (updateItem != null)
            {
                updateItem.Quanlity = cartDetails.Quanlity;
                updateItem.TotalPrice = cartDetails.ProductDetail.Price * cartDetails.Quanlity;

                _context.CartDetails.Update(updateItem);
                await _context.SaveChangesAsync();
            }
        }
        public async Task RemoveFromCartAsync(Guid cartDetailsId)
        {
            var deleteItem = await _context.CartDetails.FindAsync(cartDetailsId);
            if (deleteItem != null)
            {
                _context.CartDetails.Remove(deleteItem);
                await _context.SaveChangesAsync();
            }
        }
    }
}
