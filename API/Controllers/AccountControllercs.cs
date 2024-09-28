using API.IRepositories;
using Data.ViewModels;
using DataProcessing.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountControllercs : ControllerBase
    {
        private readonly IAccountRepo _repo;

        public AccountControllercs(IAccountRepo repo)
        {
            _repo = repo;
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(SignInModel model)
        {
            var result = await _repo.SignInAsync(model);
            if (string.IsNullOrEmpty(result))
            {
                return Unauthorized();
            }
            return Ok(result);
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(SignUpModel model)
        {
            try
            {
                var result = await _repo.SignUpAsync(model);
                if (result.Succeeded)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            catch (Exception ex)
            {
                return BadRequest( $"{ex.Message}");
            }
        }
        [HttpPost("Create-Employee")]
        public async Task<IActionResult> CreateEmployee(CreateAccountModelcs models)

        {
            try
            {
                var result = await _repo.CreateEmployee(models);
                if (result.Succeeded)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }
        [HttpGet("Get-All-Employee")]
        public async Task<IActionResult> GetAllEmployee()
        {
            try
            {
                var result = await _repo.GetAllEmployee();
                return Ok(result);
            }
            catch(Exception ex) 
            {
                return BadRequest($"{ex.Message}");
            }
        }
        [HttpGet("GetById-Employee")]
        public async Task<IActionResult> GetEmployeeById(Guid idEmployee)
        {
            try
            {
                var result = await _repo.GetEmployeeById(idEmployee);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }
        [HttpPut("Update-Employee")]
        public async Task<IActionResult> UpdateEmployee(ApplicationUser employee)
        {
            try
            {
                var result = await _repo.UpdateEmployee(employee);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }
        [HttpDelete("Delete-Employee")]
        public async Task<IActionResult> DeleteEmployee(Guid idEmployee)
        {
            try
            {
                var result = await _repo.DeleteEmployee(idEmployee);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }
        [HttpPost("Create-Customer")]
        public async Task<IActionResult> CreateCustomer(CreateAccountModelcs model)
        {
            try
            {
                var result = await _repo.CreateCustomer(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }
        [HttpPut("Update-Customer")]
        public async Task<IActionResult> UpdateCustomer(ApplicationUser customer)
        {
            try
            {
                var result = await _repo.UpdateCustomer(customer);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }
        [HttpDelete("Delete-Customer")]
        public async Task<IActionResult> DeleteCustomer(Guid idCustomer)
        {
            try
            {
                var result = await _repo.DeleteCustomer(idCustomer);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }
        [HttpGet("GetById-Customer")]
        public async Task<IActionResult> GetCustomerById( Guid idCustomer)
        {
            try
            {
                var result = await _repo.GetCustomerById(idCustomer);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }
        [HttpGet("Get-All-Customer")]
        public async Task<IActionResult> GetAllCustomer()
        {
            try
            {
                var result = await _repo.GetAllCustomer();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }




    }
}
