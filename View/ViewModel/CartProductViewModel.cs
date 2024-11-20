using DataProcessing.Models;

namespace View.ViewModel
{
    public class CartProductViewModel
    {
        public CartDetail? cartDetail { get; set; }
        public ProductDetail? productDetail {get;set;}
    }

    public class CartVM
    {
        public IEnumerable<Product>? Products { get; set; }
        public IEnumerable<CartDetail>? CartDetails { get; set; }
        public IEnumerable<SelectedImage>? ImagesForProduct { get; set; }
        public IEnumerable<ProductDetail>? ProductDetails { get; set; }


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
