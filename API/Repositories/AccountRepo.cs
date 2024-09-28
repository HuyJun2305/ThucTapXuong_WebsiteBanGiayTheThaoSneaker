using API.Data;
using API.IRepositories;
using Data.ViewModels;
using DataProcessing.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;
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
                    Id = Guid.NewGuid(),
                    Name = model.Name,
                    Birthday=model.BirthDay,
                    PhoneNumber = model.PhoneNumber,
                    UserName = model.Email,
                    Email = model.Email,
                    CIC = model.CIC // Gán giá trị cho CIC

                };
                var result = await _userManager.CreateAsync(account, model.Password);
                if (result.Succeeded)
                {
                    await CreateCartForUser(account.Id);
                    var roleResult = await _userManager.AddToRoleAsync(account, "Customer");
                }
                return result;
            }
            catch (Exception ex)
            {
                var innerException = ex.InnerException != null ? ex.InnerException.Message : "No inner exception";
                Console.WriteLine($"Xảy ra lỗi khi tạo tài khoản: {ex.Message}\nInner Exception: {innerException}");
                throw;
                
            }
        }
        private async Task CreateCartForUser(Guid userId)
        {
            var userCart = new Cart
            {
                Id = Guid.NewGuid(),
                AccountId = userId
            };
            _context.Carts.Add(userCart);

        }
        public async Task<IdentityResult> CreateEmployee(CreateAccountModelcs models )
        {
            try
            {
                var account = new ApplicationUser
                {
                    Id = Guid.NewGuid(),
                    Name = models.Name,
                    Birthday = models.BirthDay,
                    PhoneNumber = models.PhoneNumber,
                    UserName = models.Email,
                    Email = models.Email,
                    CIC = models.CIC 

                };
                var result = await _userManager.CreateAsync(account, models.Password);
                if (result.Succeeded)
                {
                    await CreateCartForUser(account.Id);
                    var roleResult = await _userManager.AddToRoleAsync(account, "Employee");
                }
                return result;
            }
            catch (Exception ex)
            {
                var innerException = ex.InnerException != null ? ex.InnerException.Message : "No inner exception";
                Console.WriteLine($"Xảy ra lỗi khi tạo tài khoản: {ex.Message}\nInner Exception: {innerException}");
                throw;

            }
        }

        public async Task<List<ApplicationUser>> GetAllEmployee()
        {
            try
            {
                var employees = await _userManager.Users.ToListAsync();
                var employeeList = new List<ApplicationUser>();
                foreach (var user in employees)
                {
                    var roles = await _userManager.GetRolesAsync(user);
                    if (roles.Contains("Employee"))
                    {
                        employeeList.Add(user);
                    }
                }   
                return employeeList;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lấy danh sách nhân viên: {ex.Message}");
                throw;
            }
        }

        public async Task<ApplicationUser> GetEmployeeById(Guid idEmployee)
        {
            try
            {
                return await _userManager.FindByIdAsync(idEmployee.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lấy thông tin nhân viên: {ex.Message}");
                throw;
            }
        }

        public async Task<IdentityResult> UpdateEmployee(ApplicationUser employee)
        {
            try
            {
                var existingEmployee = await _userManager.FindByIdAsync(employee.Id.ToString());
                if(existingEmployee == null)
                {
                    throw new Exception("Nhân viên không tồn tại");
                }
                existingEmployee.Name = employee.Name;
                existingEmployee.Email = employee.Email;
                existingEmployee.PhoneNumber= employee.PhoneNumber;
                existingEmployee.UserName = employee.UserName;
                existingEmployee.CIC=employee.CIC;
                existingEmployee.Birthday=employee.Birthday;
                existingEmployee.PasswordHash=employee.PasswordHash;

                return await _userManager.UpdateAsync(existingEmployee);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error : {ex.Message}"); 
                throw;
            }
        }

        public async Task<IdentityResult> DeleteEmployee(Guid idEmployee)
        {
            try
            {
                var deleteEmployee = await _userManager.FindByIdAsync(idEmployee.ToString());
                if (deleteEmployee == null)
                {
                    throw new Exception("Nhân viên không tồn tại");
                }
                return await _userManager.DeleteAsync(deleteEmployee);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        public async Task<IdentityResult> CreateCustomer(CreateAccountModelcs models)
        {
            try
            {
                var account = new ApplicationUser
                {
                    Id = Guid.NewGuid(),
                    Name = models.Name,
                    Birthday = models.BirthDay,
                    PhoneNumber = models.PhoneNumber,
                    UserName = models.Email,
                    Email = models.Email,
                    CIC = models.CIC

                };
                var result = await _userManager.CreateAsync(account, models.Password);
                if (result.Succeeded)
                {
                    await CreateCartForUser(account.Id);
                    var roleResult = await _userManager.AddToRoleAsync(account, "Customer");
                }
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                throw;
            }
        }

        public async Task<IdentityResult> UpdateCustomer(ApplicationUser customer)
        {
            try
            {
                var existingCustomer = await _userManager.FindByIdAsync(customer.Id.ToString());
                if (existingCustomer == null)
                {
                    throw new Exception("Nhân viên không tồn tại");
                }
                existingCustomer.Name = customer.Name;
                existingCustomer.Email = customer.Email;
                existingCustomer.PhoneNumber = customer.PhoneNumber;
                existingCustomer.UserName = customer.UserName;
                existingCustomer.CIC = customer.CIC;
                existingCustomer.Birthday = customer.Birthday;
                existingCustomer.PasswordHash = customer.PasswordHash;

                return await _userManager.UpdateAsync(existingCustomer);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error : {ex.Message}");
                throw;
            }
        }

        public async Task<IdentityResult> DeleteCustomer(Guid idCustomer)
        {
            try
            {
                var deleteCustomer = await _userManager.FindByIdAsync(idCustomer.ToString());
                if (deleteCustomer == null)
                {
                    throw new Exception("Khách hàng không tồn tại");
                }
                return await _userManager.DeleteAsync(deleteCustomer);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                throw;
            }
        }

        public async Task<ApplicationUser> GetCustomerById(Guid idCustomer)
        {
            try
            {
                return await _userManager.FindByIdAsync(idCustomer.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                throw;
            }
        }

        public async Task<List<ApplicationUser>> GetAllCustomer()
        {
            try
            {
                var customers = await _userManager.Users.ToListAsync();
                var customersList = new List<ApplicationUser>();
                foreach (var user in customers)
                {
                    var roles = await _userManager.GetRolesAsync(user);
                    if (roles.Contains("Customer"))
                    {
                        customersList.Add(user);
                    }
                }
                return customersList;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lấy danh sách khách hàng: {ex.Message}");
                throw;
            }
        }
    }
}
