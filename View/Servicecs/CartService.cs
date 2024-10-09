using DataProcessing.Models;
using Newtonsoft.Json;
using System.Net.Http;
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

        public async Task AddToCartAsync(Guid userId, string productDetailId, int quantity)
        {
            string requestURL = $"https://localhost:7170/api/Cart/AddProductToCart?userId={userId}&productDetailId={productDetailId}&quantity={quantity}";
            var jsoncontent = JsonConvert.SerializeObject(new { userId, productDetailId, quantity });
            var content = new StringContent(jsoncontent);
            await _client.PostAsJsonAsync(requestURL, content);
        }

        public async Task<IEnumerable<CartDetail>> GetUserCartAsync(Guid userId)
        {
            string requestURL = $"https://localhost:7170/api/Cart/{userId}";
            var response = await _client.GetStringAsync(requestURL);
            return JsonConvert.DeserializeObject<IEnumerable<CartDetail>>(response);  

        }      

        public async Task RemoveFromCartAsync(Guid cartDetailId)
        {
            await _client.DeleteAsync($"https://localhost:7170/api/Cart/RemoveFromCart/{cartDetailId}");

        }

        public Task UpdateCartQuantityAsync(Guid cartDetailId, int quantity)
        {
            throw new NotImplementedException();
        }
    }
}
