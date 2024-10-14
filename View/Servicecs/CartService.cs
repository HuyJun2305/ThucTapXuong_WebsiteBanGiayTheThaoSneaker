using DataProcessing.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using View.IServices;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace View.Servicecs
{
    public class CartService:ICartService
    {
        private readonly HttpClient _client;
        public CartService(HttpClient client)
        {
            _client= client;
        }

        public async Task CreateCartDetails(CartDetail cartDetails)
        {
            await _client.PostAsJsonAsync("https://localhost:7170/api/Cart/CreateCartDetails" , cartDetails);
        }

        public Task<CartDetail> GetCartByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<CartDetail>> GetCartDetails()
        {
            throw new NotImplementedException();
        }

        public Task RemoveFromCartAsync(Guid cartDetailId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCartQuantityAsync(CartDetail cartDetails, Guid cartDetailsId)
        {
            throw new NotImplementedException();
        }
        public async Task AddToCart(Guid cartId, CartDetail cartDetails)
        {
            var cartDetail = _client.PostAsJsonAsync("https://localhost:7170/api/Cart/CreateCartDetails", cartDetails);
            var cart = await _client.GetAsync($"https://localhost:7170/api/Cart/GetById-{cartId}");
            if(cart.IsSuccessStatusCode)
            {
                var cartItem = await cart.Content.ReadAsStringAsync();
            }    
        }
    }
}
