using DataProcessing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class ProductDetailPromotion
    {
        public string ProductDetailId { get; set; }
        public ProductDetail ProductDetail { get; set; }

        public Guid PromotionId { get; set; }
        public Promotion Promotion { get; set; }
    }
}
