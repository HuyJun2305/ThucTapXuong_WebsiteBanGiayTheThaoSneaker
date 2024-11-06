using Data.Models;
using DataProcessing.Models;

namespace API.IRepositories
{
    public interface IVoucherRepos
    {
        Task<List<Voucher>> GetAll();
        Task<Voucher> GetById(Guid id);
        Task create(Voucher voucher);
        Task update(Voucher voucher);
        Task delete(Guid id);
        Task SaveChanges();
    }
    public interface IVoucherUserRepo
    {
        Task<List<VoucherUser>> GetAll();
        Task<VoucherUser> GetById(Guid id);
        Task create(VoucherUser voucherUser);
        Task update(VoucherUser voucherUser);
        Task delete(Guid id);
        Task SaveChanges();
    }
}
