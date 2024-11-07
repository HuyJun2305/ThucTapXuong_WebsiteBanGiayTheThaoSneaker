using Data.Models;
using DataProcessing.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Net.Http.Json;
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

        public async Task AssignVoucherToCustomer(Guid voucherId, Guid customerId)
        {
            var customerVoucher = new CustomerVoucher 
            {
                VoucherId = voucherId,
                CustomerId = customerId
            };

            var response = await _httpClient.PostAsJsonAsync("https://localhost:7170/api/CustomerVoucher", customerVoucher);
            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Failed to assign voucher to customer. Status Code: {response.StatusCode}, Error: {errorContent}");
            }
        }

        // Create Voucher
        public async Task Create(Voucher voucher)
        {
            var response = await _httpClient.PostAsJsonAsync("https://localhost:7170/api/Voucher", voucher);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                // Kiểm tra nếu thông báo lỗi liên quan đến trùng mã VoucherCode
                if (response.StatusCode == System.Net.HttpStatusCode.BadRequest && errorContent.Contains("Mã phiếu giảm giá đã tồn tại"))
                {
                    throw new ArgumentException("Mã phiếu giảm giá đã tồn tại.");
                }
                throw new Exception($"Failed to create voucher. Status Code: {response.StatusCode}, Error: {errorContent}");
            }
        }

        // Delete Voucher
        public async Task Delete(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"https://localhost:7170/api/Voucher/{id}");

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Failed to delete voucher. Status Code: {response.StatusCode}, Error: {errorContent}");
            }
        }

        // Phương thức lấy tất cả các tài khoản
        public async Task<List<ApplicationUser>> GetAllAccounts()
        {
            var response = await _httpClient.GetAsync("https://localhost:7170/api/AccountControllercs/Get-All-Customer");

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Failed to retrieve accounts. Status Code: {response.StatusCode}, Error: {errorContent}");
            }

            var responseString = await response.Content.ReadAsStringAsync();
            var accounts = JsonConvert.DeserializeObject<List<ApplicationUser>>(responseString);
            return accounts;
        }

        // Get All Vouchers
        public async Task<IEnumerable<Voucher>?> GetAllVouchers()
        {
            var response = await _httpClient.GetAsync("https://localhost:7170/api/Voucher");

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Failed to retrieve vouchers. Status Code: {response.StatusCode}, Error: {errorContent}");
            }

            var responseString = await response.Content.ReadAsStringAsync();
            var vouchers = JsonConvert.DeserializeObject<IEnumerable<Voucher>>(responseString);
            return vouchers;
        }

        // Get Voucher by ID
        public async Task<Voucher?> GetVoucherById(Guid id)
        {
            var response = await _httpClient.GetAsync($"https://localhost:7170/api/Voucher/{id}");

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Failed to retrieve voucher. Status Code: {response.StatusCode}, Error: {errorContent}");
            }

            var responseString = await response.Content.ReadAsStringAsync();
            var voucher = JsonConvert.DeserializeObject<Voucher>(responseString);
            return voucher;
        }

        public async Task<List<Voucher>> GetVouchersByCustomerId(Guid customerId)
        {
            var response = await _httpClient.GetAsync($"https://localhost:7170/api/CustomerVoucher/customer/{customerId}");

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Failed to retrieve customer vouchers. Status Code: {response.StatusCode}, Error: {errorContent}");
            }

            var responseString = await response.Content.ReadAsStringAsync();
            var vouchers = JsonConvert.DeserializeObject<List<Voucher>>(responseString);
            return vouchers;
        }

        // Kiểm tra tính duy nhất của VoucherCode bằng cách gọi API
        public async Task<bool> IsVoucherCodeUnique(string voucherCode)
        {
            var response = await _httpClient.GetAsync($"https://localhost:7170/api/Voucher/is-voucher-code-unique?voucherCode={voucherCode}");

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Failed to check uniqueness of voucher code. Status Code: {response.StatusCode}, Error: {errorContent}");
            }

            var isUnique = await response.Content.ReadAsStringAsync();
            return bool.Parse(isUnique); // trả về kết quả kiểm tra tính duy nhất của mã voucher
        }
        
        // Update Voucher
        public async Task Update(Voucher voucher)
        {
            var response = await _httpClient.PutAsJsonAsync($"https://localhost:7170/api/Voucher/{voucher.Id}", voucher);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Failed to update voucher. Status Code: {response.StatusCode}, Error: {errorContent}");
            }
        }
    }
}
