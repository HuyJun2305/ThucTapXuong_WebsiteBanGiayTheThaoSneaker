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
    }
}
