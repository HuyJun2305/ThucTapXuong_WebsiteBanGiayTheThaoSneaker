using API.IRepositories;
using Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerVoucherController : Controller
    {
        private readonly ICustomerVoucherRepos _customerVoucherRepos;
        public CustomerVoucherController(ICustomerVoucherRepos customerVoucherRepository)
        {
            _customerVoucherRepos = customerVoucherRepository;
        }

        // POST: api/CustomerVoucher
        [HttpPost]
        public async Task<IActionResult> AssignVoucherToCustomer([FromBody] CustomerVoucher customerVoucher)
        {
            if (customerVoucher == null || customerVoucher.CustomerId == Guid.Empty || customerVoucher.VoucherId == Guid.Empty)
            {
                return BadRequest(new { Message = "Invalid data. CustomerId and VoucherId are required." });
            }

            try
            {
                await _customerVoucherRepos.AssignVoucherToCustomer(customerVoucher);
                return Ok(new { Message = "Voucher assigned to customer successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"Error assigning voucher: {ex.Message}" });
            }
        }
        // GET: api/CustomerVoucher/customer/{customerId}
        [HttpGet("customer/{customerId}")]
        public async Task<IActionResult> GetVouchersByCustomerId(Guid customerId)
        {
            var vouchers = await _customerVoucherRepos.GetVouchersByCustomerId(customerId);

            if (vouchers == null || !vouchers.Any())
            {
                return NotFound(new { Message = "No vouchers found for this customer." });
            }
            return Ok(vouchers);
        }
    }
}
