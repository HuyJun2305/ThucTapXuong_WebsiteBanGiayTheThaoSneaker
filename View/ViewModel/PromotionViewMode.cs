using API.DTO;

namespace View.ViewModel
{
    public class PromotionViewMode
    {

           public List<Guid> SelectedProductIds { get; set; }
           public List<ProductDetailDTO> ProductVariants { get; set; }


    }
    public class ProductViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
    public class ProductDetailsPromotionViewModel
    {
        public string Name { get; set; }
        public decimal DiscountValue { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Status { get; set; }
        public List<string> SelectedProductDetailIds { get; set; }
    }


}
