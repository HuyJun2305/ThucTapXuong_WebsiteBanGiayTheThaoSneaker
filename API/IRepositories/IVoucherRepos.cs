using DataProcessing.Models;

namespace API.IRepositories
{
    public interface IVoucherRepos
    {
        Task<List<Voucher>> GetAll();
        Task<Voucher> GetById(int id);
        Task create(Voucher voucher);
        Task update(Voucher voucher);
        Task delete(int id);
    }
}
