using DataProcessing.Models;
using System.Security.Principal;

namespace View.ViewModel
{
    public class VoucherViewModel
    {
        public Voucher Voucher { get; set; }
        public List<ApplicationUser> Accounts { get; set; }
        public List<Guid> SelectedCustomerIds { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }

        public VoucherViewModel()
        {
            Voucher = new Voucher(); // Khởi tạo đối tượng Voucher
            Accounts = new List<ApplicationUser>();
            SelectedCustomerIds = new List<Guid>();
        }
    }

}
