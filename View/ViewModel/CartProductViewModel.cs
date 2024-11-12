using DataProcessing.Models;

namespace View.ViewModel
{
    public class CartProductViewModel
    {
        public CartDetail? cartDetail { get; set; }
        public ProductDetail? productDetail {get;set;}
    }

    //public class CartToPayment
    //{
    //    public List<CartDetail>? cartDetails { get; set; }
    //    public List<GetQuantity> getQuantities { get; set; }
    //}

    //public class GetQuantity
    //{
    //    public Guid ProductId { get; set; }
    //    public int Quantity { get; set; }
    //}
}
