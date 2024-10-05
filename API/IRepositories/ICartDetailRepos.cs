using DataProcessing.Models;

namespace API.IRepositories
{
    public interface ICartDetailRepos
    {
        Task<List<CartDetail>> GetAllCartDetails();
        Task<CartDetail> GetCartDetailById(Guid id);
        Task<List<CartDetail>> GetCartDetailsByCartId(Guid cartId);
        Task Create(CartDetail cartDetail);
        Task Update(CartDetail cartDetail);
        Task Delete(Guid id);
        Task SaveChanges();
    }
}
