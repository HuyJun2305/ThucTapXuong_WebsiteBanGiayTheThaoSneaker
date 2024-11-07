using DataProcessing.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class CustomerVoucher
    {
        public Guid VoucherId { get; set; }
        [JsonIgnore]
        public Voucher Voucher { get; set; }

        public Guid CustomerId { get; set; }
        [JsonIgnore]
        public ApplicationUser Customer { get; set; }
    }
}
