using API.IRepositories;
using API.Repositories;
using DataProcessing.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : Controller
    {
        private readonly ICartRepos _cartRepos;
        public CartController(ICartRepos repos)
        {
            _cartRepos = repos;
        }

        // GET: api/Cart
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cart>>> GetCarts()
        {
            return await _cartRepos.GetAllCarts();
        }

        // GET: api/Cart/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cart>> GetCart(Guid id)
        {
            var cart = await _cartRepos.GetCartById(id);

            if (cart == null)
            {
                return NotFound();
            }

            return cart;
        }

        // PUT: api/Cart/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCart(Guid id, Cart cart)
        {
            if (id != cart.Id)
            {
                return BadRequest();
            }

            try
            {
                await _cartRepos.Update(cart);
                await _cartRepos.SaveChanges();
            }
            catch (Exception)
            {
                if (await _cartRepos.GetCartById(id) == null)
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

        // POST: api/Cart
        [HttpPost]
        public async Task<ActionResult<Cart>> PostCart(Cart cart)
        {
            try
            {
                await _cartRepos.Create(cart);
                await _cartRepos.SaveChanges();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }

            return CreatedAtAction("GetCart", new { id = cart.Id }, cart);
        }

        // DELETE: api/Cart/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCart(Guid id)
        {
            try
            {
                await _cartRepos.Delete(id);
                await _cartRepos.SaveChanges();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }

            return Content("Cart deleted successfully");
        }
    }
}
