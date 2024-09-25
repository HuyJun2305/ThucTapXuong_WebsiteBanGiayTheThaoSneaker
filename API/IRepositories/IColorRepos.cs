using System.Drawing;

namespace API.IRepositories
{
    public interface IColorRepos
    {
        Task<List<Color>> GetAll();
        Task<Color> GetColorById(Guid id);
        Task Create(Color color);
        Task Update(Color color);
        Task Delete(Guid id);
        Task SaveChanges();
        
    }
}
