using DataProcessing.Models;

namespace API.IRepositories
{
    public interface ICartDetailsRepo
    {
        Task CreateCartDetails(CartDetail cartDetails);
        Task<List<CartDetail>> GetCartDetails();
        Task<CartDetail> GetCartDetailByIdAsync(Guid id);
        Task UpdateCartQuantityAsync(CartDetail cartDetails , Guid cartDetailsId);
        Task RemoveFromCartAsync(Guid cartDetailId);
    }
}
