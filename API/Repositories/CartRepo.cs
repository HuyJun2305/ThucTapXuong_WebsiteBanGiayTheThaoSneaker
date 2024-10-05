using API.Data;
using API.IRepositories;
using DataProcessing.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class CartRepo:ICartRepo
    {
        private readonly ApplicationDbContext _context;
        public CartRepo(ApplicationDbContext context)
        {
            _context=context;
        }
        public async Task AddToCartAsync(Guid userId, string productDetailId, int quantity)
        {
            var cart = await _context.Carts.Include(c=>c.CartDetails).FirstOrDefaultAsync(c=>c.Account.Id == userId);
            if (cart == null)
            {
                cart = new Cart
                {
                    Id = Guid.NewGuid(),
                    AccountId = userId,
                    CartDetails = new List<CartDetail>()
                };
                _context.Carts.Add(cart);
            }
            var cartDetails = cart.CartDetails.FirstOrDefault(cd => cd.ProductDetailId == productDetailId);
            // checl tồn tại sản phẩm 
            if(cartDetails != null)
            {
                cartDetails.Quanlity += quantity; // nếu sp có trong cart rồi thì cộng dồn
            }    
            else
            {
                var productDetails = await _context.ProductDetails.FindAsync(productDetailId);
                if (productDetails != null)
                {
                    cart.CartDetails.Add(new CartDetail
                    {
                        Id= Guid.NewGuid(),
                        ProductDetailId= productDetailId,
                        Quanlity=quantity,
                        TotalPrice = productDetails.Price * quantity,
                        CartId = cart.Id
                    });

                }
            }    
            await _context.SaveChangesAsync();  

        }
        // danh sách cart details của user 
        public async Task<IEnumerable<CartDetail>> GetUserCartAsync(Guid userId)
        {
            // Tìm giỏ hàng của người dùng
            var cart = await _context.Carts
                .Include(c => c.CartDetails) // Bao gồm thông tin CartDetails
                    .ThenInclude(cd => cd.ProductDetail) // Bao gồm thông tin ProductDetail
                .FirstOrDefaultAsync(c => c.AccountId == userId);


            return cart?.CartDetails ?? Enumerable.Empty<CartDetail>();
        }

        public async Task UpdateCartQuantityAsync(Guid cartDetailId, int quantity)
        {
            var cartDetail = await _context.CartDetails.FindAsync(cartDetailId);
            if (cartDetail != null)
            {
                cartDetail.Quanlity = quantity;
                cartDetail.TotalPrice = cartDetail.ProductDetail.Price * quantity;

                await _context.SaveChangesAsync();
            }
        }
        public async Task RemoveFromCartAsync(Guid cartDetailId)
        {
            var cartDetail = await _context.CartDetails.FindAsync(cartDetailId);
            if (cartDetail != null)
            {
                _context.CartDetails.Remove(cartDetail);
                await _context.SaveChangesAsync();
            }
        }
    }
}
