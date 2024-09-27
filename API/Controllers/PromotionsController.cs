using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Data;
using DataProcessing.Models;
using API.IRepositories;
using API.Repositories;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromotionsController : ControllerBase
    {
        private readonly IPromotionRepos _PromorionRepos;

        public PromotionsController(IPromotionRepos promorionRepos)
        {
            _PromorionRepos = promorionRepos;
        }



        // GET: api/Promotions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Promotion>>> GetPromotions()
        {
            try
            {
                var promotions = await _PromorionRepos.GetAllPromotion();
                return Ok(promotions);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // GET: api/Promotions/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Promotion>> GetPromotion(Guid id)
        {
            try
            {
                var promotion = await _PromorionRepos.GetPromotionById(id);
                if (promotion == null)
                {
                    return NotFound();
                }
                return Ok(promotion);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // PUT: api/Promotions/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPromotion(Guid id, Promotion promotion)
        {
            if (id != promotion.Id)
            {
                return BadRequest(new { message = "Promotion ID mismatch." });
            }

            try
            {
                await _PromorionRepos.Update(promotion);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }

            return NoContent();
        }

        // POST: api/Promotions
        [HttpPost]
        public async Task<ActionResult<Promotion>> PostPromotion(Promotion promotion)
        {
            try
            {
                await _PromorionRepos.Create(promotion);
                return CreatedAtAction(nameof(GetPromotion), new { id = promotion.Id }, promotion);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // DELETE: api/Promotions/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePromotion(Guid id)
        {
            try
            {
                await _PromorionRepos.Delete(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
