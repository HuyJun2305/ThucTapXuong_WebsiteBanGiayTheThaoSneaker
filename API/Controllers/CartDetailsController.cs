using API.IRepositories;
using DataProcessing.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartDetailsController : ControllerBase
    {
        private readonly ICartDetailsRepo _cartRepo;

        public CartDetailsController( ICartDetailsRepo cartRepo)
        {
            _cartRepo=cartRepo;
        }
        [HttpPost("CreateCartDetails")]
        public async Task<IActionResult> CreateCartDetails(CartDetail cartDetail)
        {
            try
            {
                await _cartRepo.CreateCartDetails(cartDetail);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
     
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetCartDetails()
        {
            try
            {
                var cartDetails = await _cartRepo.GetCartDetails();
                return Ok(cartDetails);
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }
            
        }
        [HttpGet("{cartDetailId}")]
        public async Task<IActionResult> GetCartDetailByIdAsync(Guid cartDetailId)
        {
            try
            {
                var cartDetail = await _cartRepo.GetCartDetailByIdAsync(cartDetailId);
                return Ok(cartDetail);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //[HttpGet("{cartId}")]
        //public async Task<IActionResult> GetCartById(Guid cartId)
        //{
        //    try
        //    {
        //        var cartDetail = await _cartRepo.GetCartById(cartId);
        //        return Ok(cartDetail);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}
        [HttpPut("updateCartDetails{cartDeatailsId}")]
        public async Task<IActionResult> UpdateCartQuantity(CartDetail cartDetails, Guid cartDetailsId)
        {
            try
            {
                await _cartRepo.UpdateCartQuantityAsync(cartDetails, cartDetailsId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{cariDetailsId}")]
        public async Task<IActionResult> RemoveFromCart(Guid cartDetailId)
        {
            try
            {
                await _cartRepo.RemoveFromCartAsync(cartDetailId);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
