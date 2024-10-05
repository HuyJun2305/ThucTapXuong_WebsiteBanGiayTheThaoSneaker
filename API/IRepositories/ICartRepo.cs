using DataProcessing.Models;

namespace API.IRepositories
{
    public interface ICartRepo
    {
        Task AddToCartAsync(Guid userId, string productDetailId, int quantity);
        Task<IEnumerable<CartDetail>> GetUserCartAsync(Guid userId);
        Task UpdateCartQuantityAsync(Guid cartDetailId, int quantity);
        Task RemoveFromCartAsync(Guid cartDetailId);
    }
}
