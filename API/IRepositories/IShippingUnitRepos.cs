using DataProcessing.Models;

namespace API.IRepositories
{
    public interface IShippingUnitRepos
    {
        Task<List<ShippingUnit>> GetAllShippingUnit();
        Task<ShippingUnit> GetShippingUnitById(Guid shippingUnitId);
        Task create(ShippingUnit shippingUnit);
        Task update(ShippingUnit shippingUnit);
        Task delete(Guid shippingUnitId);
        Task SaveChanges();
    }
}
