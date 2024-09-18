using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessing.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal TotalPrice { get; set; }
        public string PaymentMethod { get; set; }
        public string Status { get; set; }

        public Guid UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public Guid VoucherId { get; set; }
        public virtual Voucher Voucher { get; set; }
    }
}
