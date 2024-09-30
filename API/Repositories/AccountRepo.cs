using API.Data;
using API.IRepositories;
using Data.ViewModels;
using DataProcessing.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net.WebSockets;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace API.Repositories
{
    public class AccountRepo : IAccountRepo
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;
        private readonly ApplicationDbContext _context;

        public AccountRepo(UserManager<ApplicationUser> userManager , SignInManager<ApplicationUser> signInManager, IConfiguration configuration, RoleManager<IdentityRole<Guid>> roleManager , ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _roleManager = roleManager;
            _context = context; 
        }
        public async Task<string> SignInAsync(SignInModel signInModel)
        {
            var user = await _userManager.FindByEmailAsync(signInModel.Email);
            var passwordValid = await _userManager.CheckPasswordAsync(user, signInModel.Password);

            if (user == null || !passwordValid)
            {
                return string.Empty;
            }

            var authClaim = new List<Claim>
            {
                new Claim(ClaimTypes.Email, signInModel.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var userRoles = await _userManager.GetRolesAsync(user);
            foreach (var role in userRoles)
            {
                authClaim.Add(new Claim(ClaimTypes.Role, role.ToString()));
            }
            var authenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddMinutes(10), // time hết hạn token 
                claims: authClaim,
                signingCredentials: new SigningCredentials(authenKey, SecurityAlgorithms.HmacSha512) // MÃ HÓA
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<IdentityResult> SignUpAsync(SignUpModel model  )
        {
            try
            {
                var account = new ApplicationUser
                {
                    Id = new Guid(),
                    Name = model.Name,
                    PhoneNumber = model.PhoneNumber,
                    UserName = model.Email

                };
                var result = await _userManager.CreateAsync(account, model.Password);
                if (result.Succeeded)
                {
                    await CreateCartForUser(account.Id);
                    var roleResult = await _userManager.AddToRoleAsync(account, "User");
                }
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Xảy ra lỗi khi tạo tài khoản: {ex.Message}");
                throw;
            }
        }
        private async Task CreateCartForUser(Guid userId)
        {
            var userCart = new Cart
            {
                Id = new Guid(),
                AccountId = userId
            };
            _context.Carts.Add(userCart);

        }
    }
}
