using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessing.Models
{
    public class Account_Voucher
    {
        public Guid Id { get; set; }
        public virtual ICollection<Voucher> Voucher { get; set; }
        public virtual ICollection<ApplicationUser> Account { get; set; }

    }
}
