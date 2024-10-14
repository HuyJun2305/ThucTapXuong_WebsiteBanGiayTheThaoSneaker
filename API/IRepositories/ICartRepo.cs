using DataProcessing.Models;

namespace API.IRepositories
{
    public interface ICartRepo
    {
         Task<List<Cart>> GetAllCart();
        Task<Cart> GetById(Guid id);
        Task Create(Cart cart);
        Task Update(Guid id, Cart cart);
        Task Delete(Guid id);

    }
}
