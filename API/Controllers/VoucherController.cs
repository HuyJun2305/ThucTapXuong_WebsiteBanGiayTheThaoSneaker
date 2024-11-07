using API.IRepositories;
using API.Repositories;
using DataProcessing.Models;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoucherController : ControllerBase
    {
        private readonly IVoucherRepos _voucherRepos;

        public VoucherController(IVoucherRepos voucherRepos)
        {
            _voucherRepos = voucherRepos;
        }

        // GET: api/voucher
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Voucher>>> GetAllVouchers()
        {
            return await _voucherRepos.GetAll();
        }

        // GET: api/voucher/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Voucher>> GetVoucherById(Guid id)
        {
            var voucher = await _voucherRepos.GetById(id);
            if (voucher == null)
            {
                return NotFound(new { Message = "Voucher not found." });
            }
            return Ok(voucher);
        }

        // POST: api/voucher
        [HttpPost]
        public async Task<ActionResult<Voucher>> CreateVoucher([FromBody] Voucher voucher)
        {
            if (voucher == null)
                return BadRequest(new { Message = "Invalid voucher data." });

            var isVoucherCodeUnique = await _voucherRepos.IsVoucherCodeUnique(voucher.VoucherCode);
            if (!isVoucherCodeUnique)
            {
                return BadRequest(new { Message = "Mã phiếu giảm giá đã tồn tại." });
            }

            try
            {
                await _voucherRepos.create(voucher);
                return CreatedAtAction(nameof(GetVoucherById), new { id = voucher.Id }, voucher);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }

        // PUT: api/voucher/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateVoucher(Guid id, [FromBody] Voucher voucher)
        {
            if (voucher == null || voucher.Id != id)
                return BadRequest(new { Message = "Invalid voucher data." });

            var existingVoucher = await _voucherRepos.GetById(id);
            if (existingVoucher == null)
            {
                return NotFound(new { Message = "Voucher not found." });
            }

            try
            {
                await _voucherRepos.update(voucher);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }

        // DELETE: api/voucher/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteVoucher(Guid id)
        {
            var voucher = await _voucherRepos.GetById(id);
            if (voucher == null)
            {
                return NotFound(new { Message = "Voucher not found." });
            }

            try
            {
                await _voucherRepos.delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        // GET: api/voucher/is-voucher-code-unique?voucherCode=XXXX
        [HttpGet("is-voucher-code-unique")]
        public async Task<IActionResult> IsVoucherCodeUnique([FromQuery] string voucherCode)
        {
            var isUnique = await _voucherRepos.IsVoucherCodeUnique(voucherCode);
            return Ok(isUnique); // trả về true nếu VoucherCode là duy nhất, false nếu trùng lặp
        }

        // GET: api/voucher/applicable
        [HttpGet("applicable")]
        public async Task<ActionResult<IEnumerable<Voucher>>> GetApplicableVouchers()
        {
            var vouchers = await _voucherRepos.GetAll();
            var applicableVouchers = vouchers
                .Where(v => v.Status && v.StartDate <= DateTime.Now && v.EndDate >= DateTime.Now && v.Stock > 0)
                .OrderByDescending(v => v.DiscountAmount > 0 ? v.DiscountAmount : v.DiscountPercent)
                .ToList();
            return Ok(applicableVouchers);
        }
    }
}
