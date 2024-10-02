using DataProcessing.Models;

namespace View.IServices
{
    public interface IShippingUnitServices
    {
        Task<List<ShippingUnit>> GetAllShippingUnit();
        Task<ShippingUnit> GetShippingUnitById(Guid? shippingUnitId);
        Task create(ShippingUnit shippingUnit);
        Task update(ShippingUnit shippingUnit);
        Task delete(Guid? shippingUnitId);
    }
}
