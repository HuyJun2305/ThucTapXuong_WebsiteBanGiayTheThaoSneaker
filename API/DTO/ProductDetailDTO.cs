using Data.Models;
using DataProcessing.Models;
using System.ComponentModel.DataAnnotations;

namespace API.DTO
{
    public class ProductDetailDTO
    {
        public string Id { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public float Weight { get; set; }

        public Guid ProductId { get; set; }
        public Guid ColorId { get; set; }
        public Guid SizeId { get; set; }

    }
}
