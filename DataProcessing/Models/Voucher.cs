using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessing.Models
{
    public class Voucher
    {
        public Guid Id { get; set; }
        public string VoucherCode { get; set; }
        public string Name { get; set; }
        public string VoucherType { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal DiscountPercent { get; set; }
        public string Condittion { get; set; }
        public int Stock { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Status { get; set; }

        public virtual Account_Voucher Account_Voucher { get; set; }
    }
}
