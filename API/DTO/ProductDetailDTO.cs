using Data.Models;
using DataProcessing.Models;
using System.ComponentModel.DataAnnotations;

namespace API.DTO
{
    public class ProductDetailDTO
    {
        public string Id { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Stock { get; set; }
        [Required]
        public float Weight { get; set; }

        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }
        public Guid ColorId { get; set; }
        public virtual Color Color { get; set; }
        public Guid SizeId { get; set; }
        public virtual Size Size { get; set; }

    }
}
