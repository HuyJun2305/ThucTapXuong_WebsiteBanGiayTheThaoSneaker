using Data.Models;
using DataProcessing.Models;

namespace API.IRepositories
{
    public interface ICustomerVoucherRepos
    {
        Task AssignVoucherToCustomer(CustomerVoucher customerVoucher);
        Task<List<Voucher>> GetVouchersByCustomerId(Guid customerId);
    }
}
