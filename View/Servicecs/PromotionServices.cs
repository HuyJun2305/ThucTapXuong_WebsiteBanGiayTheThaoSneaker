using DataProcessing.Models;
using Newtonsoft.Json;
using View.IServices;

namespace View.Servicecs
{
    public class PromotionServices : IPromotionServices
    {
        private readonly HttpClient _httpClient;

        public PromotionServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task Create(Promotion promotion)
        {
            await _httpClient.PostAsJsonAsync("https://localhost:44351/api/Promotions", promotion);
        }

        public async Task Delete(Guid id)
        {
            await _httpClient.DeleteAsync($"https://localhost:44351/api/Promotions/{id}");
        }

        public async Task<List<Promotion>?> GetAllPromotion()
        {
            var response = await _httpClient.GetStringAsync("https://localhost:44351/api/Promotions");
            var listPromotion = JsonConvert.DeserializeObject<List<Promotion>>(response);
            return listPromotion;
        }

        public async Task<Promotion?> GetPromotionById(Guid? id)
        {
            var response = await _httpClient.GetStringAsync($"https://localhost:44351/api/Promotions/{id}");
            var PromotionItem = JsonConvert.DeserializeObject<Promotion>(response);
            return PromotionItem;
        }

        public async Task Update(Promotion promotion)
        {
            await _httpClient.PutAsJsonAsync($"https://localhost:44351/api/Promotions/{promotion.Id}", promotion);
        }
    }
}
