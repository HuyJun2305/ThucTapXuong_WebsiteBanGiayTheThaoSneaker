using System.Drawing;

namespace API.IRepositories
{
    public interface ISizeRepos
    {
        Task<List<Size>> GetAllSize();
        Task <Size> GetSizeById(Guid id );
        Task Create(Size size );
        Task Update(Size size );
        Task Delete(Guid id );
    }
}
