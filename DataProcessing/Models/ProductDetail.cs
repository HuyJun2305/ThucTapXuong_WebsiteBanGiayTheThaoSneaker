using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessing.Models
{
    public class ProductDetail
    {
        public Guid Id { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public float Weight { get; set; }

        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }
        public Guid ColorId { get; set; }
        public virtual Color Color { get; set; }
        public Guid SizeId { get; set; }
        public virtual Size Size { get; set; }

    }
}
