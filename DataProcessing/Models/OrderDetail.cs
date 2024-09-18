using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessing.Models
{
    public class OrderDetail
    {
        public Guid Id { get; set; }
        public decimal TotalPrice { get; set; }
        public int Quantity { get; set; }


        public Guid OrderId { get; set; }
        public virtual Order Order { get; set; }
        public Guid ProductDetailId { get; set; }
        public virtual ProductDetail ProductDetail { get; set; }
    }
}
