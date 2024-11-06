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

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoucherUsersController : ControllerBase
    {
        private readonly IVoucherUserRepo _voucherUserRepo;

        public VoucherUsersController(IVoucherUserRepo voucherUserRepo)
        {
            _voucherUserRepo = voucherUserRepo;
        }



        // GET: api/VoucherUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VoucherUser>>> GetvoucherUsers()
        {
            try
            {
                return await _voucherUserRepo.GetAll();

            }catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // GET: api/VoucherUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VoucherUser>> GetVoucherUser(Guid id)
        {
            try
            {
                var voucherUser = await _voucherUserRepo.GetById(id);

                if (voucherUser == null)
                {
                    return NotFound();
                }

                return voucherUser;
            }catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // PUT: api/VoucherUsers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVoucherUser(Guid id, VoucherUser voucherUser)
        {
            if (id != voucherUser.Id)
            {
                return BadRequest();
            }

           await _voucherUserRepo.update(voucherUser);

            try
            {
                await _voucherUserRepo.SaveChanges();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }

            return NoContent();
        }

        // POST: api/VoucherUsers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VoucherUser>> PostVoucherUser(VoucherUser voucherUser)
        {
            try
            {
                await _voucherUserRepo.create(voucherUser);
                await _voucherUserRepo.SaveChanges();  
                return Ok(voucherUser);

            }catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }

          
        }

        // DELETE: api/VoucherUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVoucherUser(Guid id)
        {
            try
            {
                await _voucherUserRepo.delete(id);
                await _voucherUserRepo.SaveChanges();
            }catch(Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }

            return NoContent();
        }

       
    }
}
