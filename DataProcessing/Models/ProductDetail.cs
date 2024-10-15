using Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataProcessing.Models
{
    public class ProductDetail
    {
        public string? Id { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Stock { get; set; }
        [Required]
        public float Weight { get; set; }


        //public Guid? PromotionId { get; set; }
        //public virtual Promotion Promotion { get; set; }
        [JsonIgnore]  
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }
        [JsonIgnore]
        public Guid ColorId { get; set; }
        public virtual Color Color { get; set; }
        [JsonIgnore]
        public Guid SizeId { get; set; }
        public virtual Size Size { get; set; }
        public ICollection<ProductDetailPromotion> ProductDetailPromotions { get; set; }

    }
}
