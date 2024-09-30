using API.IRepositories;
using Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
