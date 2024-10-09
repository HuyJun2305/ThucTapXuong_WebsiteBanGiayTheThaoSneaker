using API.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartRepo _cartRepo;

        public CartController( ICartRepo cartRepo)
        {
            _cartRepo=cartRepo;
        }
        [HttpPost("AddProductToCart")]
        public async Task<IActionResult> AddToCart(Guid userId, string productDetailId, int quantity)
        {
            try
            {
                if (quantity <= 0)
                {
                    return BadRequest("ố lượng sản phẩm phải lớn hơn 0");
                }
                await _cartRepo.AddToCartAsync(userId, productDetailId, quantity);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
     
        }
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserCart(Guid userId)
        {
            var cartDetails = await _cartRepo.GetUserCartAsync(userId);
            return Ok(cartDetails);
        }
        [HttpPatch("UpdateCartQuantity/{cartDetailId}")]
        public async Task<IActionResult> UpdateCartQuantity(Guid cartDetailId, [FromBody] int quantity)
        {
            if (quantity <= 0)
            {
                return BadRequest("Số lượng sản phẩm phải lớn hơn 0");
            }

            await _cartRepo.UpdateCartQuantityAsync(cartDetailId, quantity);
            return Ok();
        }
        [HttpDelete("RemoveFromCart/{cartDetailId}")]
        public async Task<IActionResult> RemoveFromCart(Guid cartDetailId)
        {
            await _cartRepo.RemoveFromCartAsync(cartDetailId);
            return Ok();
        }

    }
}
