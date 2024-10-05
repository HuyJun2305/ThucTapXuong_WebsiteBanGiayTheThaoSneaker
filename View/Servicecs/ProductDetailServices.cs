using DataProcessing.Models;
using Newtonsoft.Json;
using System.Net.Http;
using View.IServices;

namespace View.Servicecs
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly HttpClient _httpClient; 
        public ProductDetailService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task Create(ProductDetail productDetail)
        {

            await _httpClient.PostAsJsonAsync("https://localhost:7170/api/ProductDetail", productDetail);
        }

        public async Task Delete(string id)
        {
            await _httpClient.DeleteAsync($"https://localhost:7170/api/ProductDetail/{id}");
        }

        public async Task<IEnumerable<ProductDetail>?> GetAllProductDetail()
        {
            var response = await _httpClient.GetStringAsync("https://localhost:7170/api/ProductDetail");
            var productDetails = JsonConvert.DeserializeObject<IEnumerable<ProductDetail>>(response);
            return productDetails;
        }

        public async Task<ProductDetail?> GetProductDetailById(string id)
        {
            var response = await _httpClient.GetStringAsync($"https://localhost:7170/api/ProductDetail/{id}");
            var productDetails = JsonConvert.DeserializeObject<ProductDetail>(response);
            return productDetails;
        }


        public async Task Update(ProductDetail productDetail)
        {
            await _httpClient.PutAsJsonAsync($"https://localhost:7170/api/ProductDetail/{productDetail.Id}", productDetail);
        }
    }
}
