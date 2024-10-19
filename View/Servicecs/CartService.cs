using API.Migrations;
using DataProcessing.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using View.IServices;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace View.Servicecs
{
    public class CartService : ICartServices
    {
        private readonly HttpClient _client;

        public CartService(HttpClient client)
        {
            _client = client;
        }
        public async Task CreateCart(Cart cart)
        {
            await _client.PostAsJsonAsync("https://localhost:7170/api/Cart/CreateCart",cart);
        }
        public async Task CreateCartDetails(CartDetail cartDetail)
        {
            var cartDetailsItem = GetCartDetailByCartId(cartDetail.CartId).Result.Where(o => o.ProductDetailId == cartDetail.ProductDetailId).FirstOrDefault();
            if(cartDetailsItem != null)
            {
                if (cartDetailsItem.Quanlity + cartDetail.Quanlity < cartDetailsItem.ProductDetail.Stock)
                {
                    cartDetail.Quanlity += cartDetail.Quanlity;
                }    
                else
                {
                    cartDetailsItem.Quanlity = cartDetailsItem.ProductDetail.Stock;
                }
                // cập nhật tổng tiền của giỏ hàng chi tiết 
                cartDetailsItem.TotalPrice = cartDetailsItem.Quanlity * cartDetailsItem.ProductDetail.Price;
                cartDetailsItem.ProductDetail = null;
                await _client.PutAsJsonAsync($"https://localhost:7170/api/CartDetails/Update?id={cartDetailsItem.Id}", cartDetailsItem);              
            }    
            else
            {
                await _client.PostAsJsonAsync($"https://localhost:7170/api/CartDetails/Create", cartDetail);
            }    
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CartDetail>> GetAllCartDetails()
        {
            var response = await _client.GetStringAsync("https://localhost:7170/api/CartDetails/GetAllCartDetails");
            var result = JsonConvert.DeserializeObject<List<CartDetail>>(response);
            return result;
        }

        public async Task<Cart> GetCartAsync(Guid id)
        {
            var respone = await _client.GetStringAsync($"https://localhost:7170/api/Cart/GetCartById?id={id}");
            var result = JsonConvert.DeserializeObject<Cart>(respone);
            return result;
        }

        public async Task<Cart> GetCartByUserId(Guid userId)
        {
            var respone = await _client.GetStringAsync($"https://localhost:7170/api/Cart/GetCartByUserId?userId={userId}");
            var result = JsonConvert.DeserializeObject<Cart>(respone);
            return result;
        }

        public async Task<List<CartDetail>> GetCartDetailByCartId(Guid cartId)
        {
            var response = await _client.GetStringAsync($"https://localhost:7170/api/CartDetails/GetCartDetailsByCartId?cartId={cartId}");
            var result = JsonConvert.DeserializeObject<List<CartDetail>>(response);
            return result;
        }

        public async Task<Cart> GetCartDetailById(Guid id)
        {
            var response = await _client.GetStringAsync($"https://localhost:7170/api/CartDetails/GetCartDetailsById?id={id}");
            var result = JsonConvert.DeserializeObject<Cart>(response);
            return result;
        }

        public async Task Update(Cart cart, Guid id)
        {
           var cartDetailsItem = await GetCartDetailByCartId(id);
            decimal totalPrice = 0;
            if (cartDetailsItem != null)
            {
                foreach(var item in cartDetailsItem)
                {
                    totalPrice += item.TotalPrice;
                };
            }
            var cartUser = await GetCartAsync(id);
            cartUser.TotalPrice = totalPrice;
            await _client.PutAsJsonAsync($"https://localhost:7170/api/Cart/UpdateCart?id={id}",cart);
        }

        public Task Update(CartDetail cartDetail, Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
