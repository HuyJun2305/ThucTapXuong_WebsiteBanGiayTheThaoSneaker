using API.Data;
using API.IRepositories;
using DataProcessing.Models;
using DataProcessing.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class ShippingUnitRepos : IShippingUnitRepos
    {
        private readonly ApplicationDbContext _context;

        public ShippingUnitRepos(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task create(ShippingUnit shippingUnit)
        {
            if (await GetShippingUnitById(shippingUnit.ShippingUnitID) != null) throw new DuplicateWaitObjectException($"ShippingUnit : {shippingUnit.ShippingUnitID} is existed!");
            await _context.ShippingUnits.AddAsync(shippingUnit);
        }

        public async Task delete(Guid shippingUnitId)
        {
              var item = await GetShippingUnitById(shippingUnitId);
               _context.ShippingUnits.Remove(item);
        }

        public async Task<List<ShippingUnit>> GetAllShippingUnit()
        {
           return await _context.ShippingUnits.ToListAsync();
        }

        public async Task<ShippingUnit> GetShippingUnitById(Guid shippingUnitId)
        {
            return await _context.ShippingUnits.FindAsync(shippingUnitId);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public async Task update(ShippingUnit shippingUnit)
        {
             var itemUpdate = await GetShippingUnitById(shippingUnit.ShippingUnitID);
                    itemUpdate.Status = shippingUnit.Status;
                    itemUpdate.Email = shippingUnit.Email;
                    itemUpdate.Address = shippingUnit.Address;
                    itemUpdate.Phone = shippingUnit.Phone;
                    itemUpdate.Name = shippingUnit.Name;
                    itemUpdate.Website = shippingUnit.Website;

            _context.ShippingUnits.Update(itemUpdate);
        }
    }
}
