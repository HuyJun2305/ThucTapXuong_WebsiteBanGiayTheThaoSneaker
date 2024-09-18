﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessing.Models
{
    public class OrderHistory
    {
        public Guid Id { get; set; }
        public string StatusType { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Note { get; set; }

        public Guid UpdatedByUserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public Guid OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}
