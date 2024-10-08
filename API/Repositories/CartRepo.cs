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
            var user = await _context.Users.Include(u => u.Cart)
                                             .ThenInclude(c => c.CartDetails)
                                             .FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null)
            {
                throw new Exception("User not found.");
            }
            else
            {
                var product = await _context.ProductDetails.FindAsync(productDetailId);
                if (product == null)
                {
                    throw new Exception("Product not found.");
                }
                if(product.Stock < quantity)
                {
                    throw new Exception("Not enough stock available.");
                }
                // Kiểm tra giỏ hàng của người dùng (nếu chưa có thì tạo mới)
                var cart = user.Cart ?? new Cart
                {
                    Id = Guid.NewGuid(),
                    AccountId = userId,
                    CartDetails = new List<CartDetail>()
                };
                // check sản phẩm đã tồn tại trong cart chưa 
                var cartItem = await _context.CartDetails.FirstOrDefaultAsync(c => c.ProductDetailId == productDetailId);
                if (cartItem == null)
                {
                    CartDetail newCartDetails = new CartDetail()
                    {
                        Id = Guid.NewGuid(),
                        CartId = cart.Id,
                        ProductDetailId = productDetailId,
                        Quanlity = quantity,
                        TotalPrice = product.Price * quantity,
                    
                    };
                    _context.CartDetails.Add(newCartDetails);         
                }
                else
                {
                    if (product.Stock < cartItem.Quanlity + quantity)
                    // nếu số lượng sản phẩm trong kho nhỏ hơn số lượng sản phẩm thêm vào 
                    {
                        throw new Exception("Not enough stock to add the additional quantity.");
                    }
                    cartItem.Quanlity = cartItem.Quanlity + quantity; // cộng dồn
                    cartItem.TotalPrice += product.Price * quantity;       
                    _context.CartDetails.Update(cartItem);          
                }
                if (user.Cart == null)
                {
                    _context.Carts.Add(cart);
                }
                // sửa lại số lượng sản phẩm trong kho 
                product.Stock = product.Stock - quantity;
                _context.ProductDetails.Update(product);

            }
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<CartDetail>> GetUserCartAsync(Guid userId)
        {
            
            var cart = await _context.Carts
                .Include(c => c.CartDetails) // Bao gồm thông tin CartDetails
                    .ThenInclude(cd => cd.ProductDetail) // Bao gồm thông tin ProductDetail
                .FirstOrDefaultAsync(c => c.AccountId == userId);


            return cart?.CartDetails ?? Enumerable.Empty<CartDetail>();
        }

        public async Task UpdateCartQuantityAsync(Guid cartDetailId, int quantity)
        {
            if(quantity<0)
            {
                throw new Exception("Số lượng phải lớn hơn 0");
            }    
            var cartDetail = await _context.CartDetails
                                    .Include(cd => cd.ProductDetail)  // Bao gồm ProductDetail để nạp thông tin sản phẩm
                                    .FirstOrDefaultAsync(cd => cd.Id == cartDetailId);
            if (cartDetail == null)
            {
                throw new ArgumentException("Không tìm thấy sản phẩm trong giỏ hàng");
            }
            cartDetail.Quanlity = quantity;
            if (cartDetail.ProductDetail != null)
            {
                cartDetail.TotalPrice = cartDetail.ProductDetail.Price * quantity;
            }
            _context.CartDetails.Update(cartDetail);
            await _context.SaveChangesAsync();
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
