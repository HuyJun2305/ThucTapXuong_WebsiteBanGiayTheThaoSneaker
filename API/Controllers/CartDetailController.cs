using API.IRepositories;
using DataProcessing.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartDetailController : ControllerBase
    {
        private readonly ICartDetailRepos _cartDetailRepo;

        public CartDetailController(ICartDetailRepos cartDetailRepo)
        {
            _cartDetailRepo = cartDetailRepo ;
        }

        // GET: api/CartDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CartDetail>>> GetCartDetails()
        {
            return await _cartDetailRepo.GetAllCartDetails();
        }

        // GET: api/CartDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CartDetail>> GetCartDetail(Guid id)
        {
            var cartDetail = await _cartDetailRepo.GetCartDetailById(id);

            if (cartDetail == null)
            {
                return NotFound();
            }

            return cartDetail;
        }

        // PUT: api/CartDetail/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCartDetail(Guid id, CartDetail cartDetail)
        {
            if (id != cartDetail.Id)
            {
                return BadRequest();
            }

            try
            {
                await _cartDetailRepo.Update(cartDetail);
                await _cartDetailRepo.SaveChanges();
            }
            catch (Exception)
            {
                if (await _cartDetailRepo.GetCartDetailById(id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CartDetail
        [HttpPost]
        public async Task<ActionResult<CartDetail>> PostCartDetail(CartDetail cartDetail)
        {
            try
            {
                await _cartDetailRepo.Create(cartDetail);
                await _cartDetailRepo.SaveChanges();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }

            return CreatedAtAction("GetCartDetail", new { id = cartDetail.Id }, cartDetail);
        }

        // DELETE: api/CartDetail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCartDetail(Guid id)
        {
            try
            {
                await _cartDetailRepo.Delete(id);
                await _cartDetailRepo.SaveChanges();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }

            return Content("CartDetail deleted successfully");
        }
    }
}
