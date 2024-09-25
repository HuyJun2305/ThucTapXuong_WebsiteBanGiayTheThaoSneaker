using API.Data;
using API.IRepositories;
using DataProcessing.Models;

namespace API.Repositories
{
    public class VoucherRepos : IVoucherRepos
    {
        private readonly ApplicationDbContext _context;

        public VoucherRepos(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task create(Voucher v)
        {
            try
            {
               await _context.Accounts.AddAsync(v);
                await _context.SaveChangesAsync();
            }catch (Exception ex)
            {

            }
        }

        public Task delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Voucher>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Voucher> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task update(Voucher voucher)
        {
            throw new NotImplementedException();
        }
    }
}
