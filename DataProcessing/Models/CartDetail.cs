using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessing.Models
{
    public class CartDetail
    {
        public Guid Id { get; set; }
        public decimal TotalPrice { get; set; }
        public int Quanlity { get; set; }

        public Guid CartId { get; set; }
        public virtual Cart Cart { get; set; }
        //test
        public Guid ProductDetailId { get; set; }
        public ProductDetail ProductDetail { get; set; }
    }
}
