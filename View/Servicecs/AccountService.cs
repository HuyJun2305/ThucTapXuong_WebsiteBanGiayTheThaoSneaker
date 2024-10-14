using Data.ViewModels;
using DataProcessing.Models;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using NuGet.Common;
using System.Net.Http.Headers;
using System.Text;
using View.IServices;

namespace View.Servicecs
{
    public class AccountService:IAccountService
    {
        private readonly HttpClient _client;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AccountService(HttpClient client, IHttpContextAccessor httpContextAccessor)
        {
            _client = client;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task CreateCustomer(CreateAccountModelcs models)
        {
            string requestURL = "https://localhost:7170/api/AccountControllercs/Create-Customer";
            var jsonContent = JsonConvert.SerializeObject(models);
            var content = new StringContent(jsonContent);
            await _client.PostAsJsonAsync(requestURL, models);
        }

        public async Task CreateEmployee(CreateAccountModelcs models)
        {
            string requestURL = "https://localhost:7170/api/AccountControllercs/Create-Employee";
            var jsonContent = JsonConvert.SerializeObject(models);
            var content = new StringContent(jsonContent);
            await _client.PostAsJsonAsync(requestURL, models);
        }

        public async Task Delete(Guid idAccount)
        {
            string requestURL = $"https://localhost:7170/api/AccountControllercs/Delete?idAccount{idAccount}";
            await _client.DeleteAsync(requestURL);
        }

        //public async Task DeleteEmployee(Guid idEmployee)
        //{
        //    string requestURL = $"https://localhost:7170/api/AccountControllercs/Delete-Employee?idEmployee={idEmployee}";
        //    await _client.DeleteAsync(requestURL);
        //}

        public async Task<List<ApplicationUser>> GetAllCustomer()
        {
            string requestURL = "https://localhost:7170/api/AccountControllercs/Get-All-Customer";
            var response = await _client.GetStringAsync(requestURL);
            return JsonConvert.DeserializeObject<List<ApplicationUser>>(response);
        }

        public async Task<List<ApplicationUser>> GetAllEmployee()
        {
            string requestURL = "https://localhost:7170/api/AccountControllercs/Get-All-Employee";
            var response = await _client.GetStringAsync(requestURL);
            return JsonConvert.DeserializeObject<List<ApplicationUser>>(response);
        }

        public async Task<ApplicationUser> GetById(Guid idAccount)
        {
            string requestURL =$"https://localhost:7170/api/AccountControllercs/GetById?idAccount={idAccount}";
            var response = await _client.GetStringAsync(requestURL);
            return JsonConvert.DeserializeObject<ApplicationUser>(response);
        }

        //public async Task<ApplicationUser> GetEmployeeById(Guid idEmployee)
        //{
        //    string requestURL = $"https://localhost:7170/api/AccountControllercs/GetById-Employee?idEmployee={idEmployee}";
        //    var response = await _client.GetStringAsync(requestURL);
        //    return JsonConvert.DeserializeObject<ApplicationUser>(response);
        //}
        public async Task<string> SignInAsync(SignInModel signInModel)
        {
            string requestURL = "https://localhost:7170/api/AccountControllercs/Login";
            var response = await _client.PostAsJsonAsync(requestURL, signInModel);
            var content = await response.Content.ReadAsStringAsync();
            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                return null; 
            }

            return await response.Content.ReadAsStringAsync();
        }
        public async Task SignOutAsync()
        {
            string requestURL = "https://localhost:7170/api/AccountControllercs/LogOut";
            var response = await _client.PostAsync(requestURL, null);
        }
        public async Task<IdentityResult> SignUpAsync(SignUpModel signUpModel)
        {
            string requestURL = "https://localhost:7170/api/AccountControllercs/Register";
            var response = await _client.PostAsJsonAsync(requestURL , signUpModel);
            var error = await response.Content.ReadFromJsonAsync<IEnumerable<string>>();
            return IdentityResult.Failed(error.Select(error=>new IdentityError { Description =error }).ToArray());
        }

        //public async Task UpdateCustomer(ApplicationUser customer)
        //{
        //    string requestURL = $"https://localhost:7170/api/AccountControllercs/Update-Customer-{customer.Id}";
        //    var jsonContent = JsonConvert.SerializeObject(customer);
        //    var content = new StringContent(jsonContent);
        //    await _client.PutAsync(requestURL, content);
        //}

        public async Task<ApplicationUser> Update(ApplicationUser account, Guid idAccount)
        {
            string requestURL = $"https://localhost:7170/api/AccountControllercs/Update/{idAccount}";
            var jsonContent = JsonConvert.SerializeObject(account); 
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await _client.PutAsync(requestURL, content);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<ApplicationUser>();
            }
            else
            {
                throw new Exception("Unable to update account.");
            }
        }
    }
}
