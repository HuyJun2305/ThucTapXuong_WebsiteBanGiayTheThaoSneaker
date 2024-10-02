using DataProcessing.Models;
using Newtonsoft.Json;
using View.IServices;

namespace View.Servicecs
{
    public class VoucherServices : IVoucherServices
    {
        private readonly HttpClient _httpClient;

        public VoucherServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task Create(Voucher voucher)
        {
            await _httpClient.PostAsJsonAsync("https://localhost:7170/api/Voucher", voucher);
        }

        public async Task Delete(Guid id)
        {
            await _httpClient.DeleteAsync($"https://localhost:7170/api/Voucher/{id}");
        }

        public async Task<IEnumerable<Voucher>?> GetAllVouchers()
        {
            var response = await _httpClient.GetStringAsync("https://localhost:7170/api/Voucher");
            var vouchers = JsonConvert.DeserializeObject<IEnumerable<Voucher>>(response);
            return vouchers;
        }

        public async Task<Voucher?> GetVoucherById(Guid id)
        {
            var response = await _httpClient.GetStringAsync($"https://localhost:7170/api/Voucher/{id}");
            var voucher = JsonConvert.DeserializeObject<Voucher>(response);
            return voucher;
        }

        public async Task Update(Voucher voucher)
        {
            await _httpClient.PutAsJsonAsync($"https://localhost:7170/api/Voucher/{voucher.Id}", voucher);
        }
    }
}
