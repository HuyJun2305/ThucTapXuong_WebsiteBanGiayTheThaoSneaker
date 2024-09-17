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

        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Color> Colors { get; set; }
        public virtual ICollection<Size> Sizes { get; set; }

    }
}
