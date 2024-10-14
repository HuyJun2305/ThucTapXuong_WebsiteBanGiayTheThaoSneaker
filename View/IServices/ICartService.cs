using DataProcessing.Models;

namespace View.IServices
{
    public interface ICartService
    {
        Task CreateCartDetails(CartDetail cartDetails);
        Task<List<CartDetail>> GetCartDetails();
        Task<CartDetail> GetCartByIdAsync(Guid id);
        Task UpdateCartQuantityAsync(CartDetail cartDetails, Guid cartDetailsId);
        Task RemoveFromCartAsync(Guid cartDetailId); // xóa item khỏi cart 

        Task AddToCart(Guid cartId, CartDetail cartDetails);

    }
}
