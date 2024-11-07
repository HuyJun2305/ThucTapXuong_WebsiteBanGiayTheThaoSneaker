using DataProcessing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataProcessing.Models
{
    public class VoucherUser
    {
        public Guid Id { get; set; }

        public Guid voucherId { get; set; }
        [JsonIgnore]
        public virtual Voucher? Voucher { get; set; }

        public Guid? AccountId { get; set; }
        [JsonIgnore]
        public virtual ApplicationUser? ApplicationUser { get; set; }

    }
}
