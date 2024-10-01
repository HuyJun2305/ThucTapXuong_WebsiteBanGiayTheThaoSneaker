﻿using API.Data;
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
                var existingUser = await _userManager.Users
                           .FirstOrDefaultAsync(u => u.Email == models.Email ||
                                                     u.PhoneNumber == models.PhoneNumber ||
                                                     u.CIC == models.CIC);
                if (existingUser != null)
                {
                    var errors = new List<IdentityError>();

                    if (existingUser.Email == models.Email)
                        errors.Add(new IdentityError { Description = "Email đã tồn tại." });

                    if (existingUser.PhoneNumber == models.PhoneNumber)
                        errors.Add(new IdentityError { Description = "Số điện thoại đã tồn tại." });

                    if (existingUser.CIC == models.CIC)
                        errors.Add(new IdentityError { Description = "CIC đã tồn tại." });

                    return IdentityResult.Failed(errors.ToArray());
                }

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
                    //await CreateCartForUser(account.Id);
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

        public async Task<ApplicationUser> GetById(Guid idAccount)
        {
            try
            {
                return await _userManager.FindByIdAsync(idAccount.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lấy thông tin {ex.Message}");
                throw;
            }
        }

        public async Task<ApplicationUser> Update(ApplicationUser account )
        {
            var existingUser = await _userManager.FindByIdAsync(account.Id.ToString());
            if (existingUser == null)
            {
                throw new Exception("User not found");
            }

            existingUser.Name = account.Name;
            existingUser.Birthday = account.Birthday;
            existingUser.PhoneNumber = account.PhoneNumber;
            existingUser.CIC = account.CIC;
            existingUser.ImageURL = account.ImageURL;

            var result = await _userManager.UpdateAsync(existingUser);
            if (result.Succeeded)
            {
                return existingUser; // Trả về user đã cập nhật
            }

            // Xử lý lỗi nếu cần
            throw new Exception("Update failed: " + string.Join(", ", result.Errors.Select(e => e.Description)));
        }

        public async Task<IdentityResult> Delete(Guid idAccount)
        {
            try
            {
                var deleteItem = await _userManager.FindByIdAsync(idAccount.ToString());
                if (deleteItem == null)
                {
                    throw new Exception("Not Found");
                }
                var hasOrders = _context.Orders.Any(o=>o.UserId == idAccount);
                if(hasOrders)
                {
                    throw new Exception("Tài khoản đã có hóa đơn, không thể xóa");
                }    
                return await _userManager.DeleteAsync(deleteItem);
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
                var existingUser = await _userManager.Users
                    .FirstOrDefaultAsync(u => u.Email == models.Email ||
                                              u.PhoneNumber == models.PhoneNumber ||
                                              u.CIC == models.CIC);

                if (existingUser != null)
                {
                    var errors = new List<IdentityError>();

                    if (existingUser.Email == models.Email)
                        errors.Add(new IdentityError { Description = "Email đã tồn tại." });

                    if (existingUser.PhoneNumber == models.PhoneNumber)
                        errors.Add(new IdentityError { Description = "Số điện thoại đã tồn tại." });

                    if (existingUser.CIC == models.CIC)
                        errors.Add(new IdentityError { Description = "CIC đã tồn tại." });

                    return IdentityResult.Failed(errors.ToArray());
                }

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
                    await _userManager.AddToRoleAsync(account, "Customer");
                }

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                throw;
            }
        }

        //public async Task<IdentityResult> UpdateCustomer(ApplicationUser customer)
        //{
        //    try
        //    {
        //        var existingCustomer = await _userManager.FindByIdAsync(customer.Id.ToString());
        //        if (existingCustomer == null)
        //        {
        //            throw new Exception("Nhân viên không tồn tại");
        //        }
        //        existingCustomer.Name = customer.Name;
        //        existingCustomer.Email = customer.Email;
        //        existingCustomer.PhoneNumber = customer.PhoneNumber;
        //        existingCustomer.UserName = customer.UserName;
        //        existingCustomer.CIC = customer.CIC;
        //        existingCustomer.Birthday = customer.Birthday;
        //        existingCustomer.PasswordHash = customer.PasswordHash;

        //        return await _userManager.UpdateAsync(existingCustomer);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error : {ex.Message}");
        //        throw;
        //    }
        //}

        //public async Task<IdentityResult> DeleteCustomer(Guid idCustomer)
        //{
        //    try
        //    {
        //        var deleteCustomer = await _userManager.FindByIdAsync(idCustomer.ToString());
        //        if (deleteCustomer == null)
        //        {
        //            throw new Exception("Khách hàng không tồn tại");
        //        }
        //        return await _userManager.DeleteAsync(deleteCustomer);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"{ex.Message}");
        //        throw;
        //    }
        //}

        //public async Task<ApplicationUser> GetCustomerById(Guid idCustomer)
        //{
        //    try
        //    {
        //        return await _userManager.FindByIdAsync(idCustomer.ToString());
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"{ex.Message}");
        //        throw;
        //    }
        //}

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
