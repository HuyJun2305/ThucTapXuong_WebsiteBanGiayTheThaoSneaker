using Data.ViewModels;
using DataProcessing.Models;
using Microsoft.AspNetCore.Identity;

namespace View.IServices
{
    public interface IAccountService
    {
        public Task<IdentityResult> SignUpAsync(SignUpModel signUpModel);
        public Task<string> SignInAsync(SignInModel signInModel);
        public Task CreateEmployee(CreateAccountModelcs models);
        public Task<List<ApplicationUser>> GetAllEmployee();
        public Task<ApplicationUser> GetById(Guid idAccount);
        public Task<ApplicationUser> Update(ApplicationUser account , Guid idAccount);
        public Task Delete(Guid idAccount);
        public Task CreateCustomer(CreateAccountModelcs models);
        //public Task UpdateCustomer(ApplicationUser customer);
        //public Task DeleteCustomer(Guid idCustomer);
        //public Task<ApplicationUser> GetCustomerById(Guid idCustomer);
        public Task<List<ApplicationUser>> GetAllCustomer();
    }
}
