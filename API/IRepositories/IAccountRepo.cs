using Data.ViewModels;
using DataProcessing.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.IRepositories
{
    public interface IAccountRepo
    {
        public Task<IdentityResult> SignUpAsync(SignUpModel signUpModel );
        public Task<string> SignInAsync(SignInModel signInModel);
        public Task<IdentityResult> CreateEmployee(CreateAccountModelcs models);
        public Task<List<ApplicationUser>> GetAllEmployee();
        public Task<ApplicationUser> GetEmployeeById(Guid idEmployee);
        public Task<IdentityResult> UpdateEmployee(ApplicationUser employee);
        public Task<IdentityResult> DeleteEmployee(Guid idEmployee);
        public Task<IdentityResult> CreateCustomer(CreateAccountModelcs models);
        public Task<IdentityResult> UpdateCustomer(ApplicationUser customer);
        public Task<IdentityResult> DeleteCustomer(Guid idCustomer);
        public Task<ApplicationUser> GetCustomerById(Guid idCustomer);
        public Task<List<ApplicationUser>> GetAllCustomer();
    }
}
