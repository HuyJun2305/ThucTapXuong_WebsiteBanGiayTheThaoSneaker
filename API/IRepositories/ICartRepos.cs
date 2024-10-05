using DataProcessing.Models;

namespace API.IRepositories
{
    public interface ICartRepos
    {
        Task<List<Cart>> GetAllCarts();
        Task<Cart> GetCartById(Guid id);
        Task Create(Cart cart);
        Task Update(Cart cart);
        Task Delete(Guid id);
        Task SaveChanges();
    }
}
