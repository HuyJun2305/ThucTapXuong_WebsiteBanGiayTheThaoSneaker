using DataProcessing.Models;

namespace View.IServices
{
    public interface ICartServices
    {
        Task<Cart> GetCartAsync(Guid id);
        Task<Cart> GetCartByUserId(Guid userId);
        Task Update(Cart cart , Guid id);
        Task <List<CartDetail>> GetAllCartDetails();
        Task<List<CartDetail>> GetCartDetailByCartId(Guid cartId);
        Task<Cart> GetCartDetailById(Guid id);
        Task Create(CartDetail cartDetail);
        Task Update(CartDetail cartDetail,Guid id);
        Task Delete(Guid id);

    }
}
