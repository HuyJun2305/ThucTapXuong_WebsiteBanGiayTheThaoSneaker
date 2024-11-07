using API.Data;
using API.IRepositories;
using Data.Models;
using DataProcessing.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class CustomerVoucherRepos : ICustomerVoucherRepos
    {
        private readonly ApplicationDbContext _context;
        public CustomerVoucherRepos(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AssignVoucherToCustomer(CustomerVoucher customerVoucher)
        {
            _context.CustomerVouchers.Add(customerVoucher);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Voucher>> GetVouchersByCustomerId(Guid customerId)
        {
            return await _context.CustomerVouchers
                .Where(cv => cv.CustomerId == customerId)
                .Include(cv => cv.Voucher)
                .Select(cv => cv.Voucher)
                .ToListAsync();
        }
    }
}
