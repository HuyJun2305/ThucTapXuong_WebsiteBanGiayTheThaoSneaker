using DataProcessing.Models;
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
            await _httpClient.PostAsJsonAsync("https://localhost:7170/api/", promotion);
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Promotion>> GetAllPromotion()
        {
            throw new NotImplementedException();
        }

        public Task<Promotion> GetPromotionById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Promotion promotion)
        {
            throw new NotImplementedException();
        }
    }
}
