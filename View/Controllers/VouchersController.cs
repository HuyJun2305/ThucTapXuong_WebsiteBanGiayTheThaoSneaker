using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataProcessing.Models;
using View.IServices;
using View.Servicecs;

namespace View.Controllers
{
    public class VoucherController : Controller
    {
        private readonly IVoucherServices _voucherService;

        public VoucherController(IVoucherServices voucherService)
        {
            _voucherService = voucherService;
        }

        // GET: Vouchers
        public async Task<IActionResult> Index()
        {
            var vouchers = await _voucherService.GetAllVouchers();
            return vouchers != null ? View(vouchers) : Problem("Entity set 'Voucher' is null.");
        }

        // GET: Vouchers/Applicable
        public async Task<IActionResult> Applicable()
        {
            var vouchers = await _voucherService.GetAllVouchers();

            if (vouchers == null)
            {
                return Problem("Entity set 'Voucher' is null");
            }

            var applicableVouchers = vouchers
                .Where(v => v.Status
                    && v.Stock > 0
                    && (v.StartDate == null || v.StartDate <= DateTime.Now)  // Nếu có StartDate, nó phải nhỏ hơn hoặc bằng hiện tại
                    && (v.EndDate == null || v.EndDate >= DateTime.Now))    // Nếu có EndDate, nó phải lớn hơn hoặc bằng hiện tại
                .OrderByDescending(v => v.DiscountType == "Amount" ? v.DiscountAmount : v.DiscountPercent)
                .ToList();


            return View(applicableVouchers);
        }



        // GET: Vouchers/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var voucher = await _voucherService.GetVoucherById(id);
            if (voucher == null)
            {
                return NotFound();
            }

            return View(voucher);
        }

        // GET: Vouchers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vouchers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,VoucherCode,Name,DiscountType,DiscountAmount,DiscountPercent,MaxDiscountValue,Stock,Condition,StartDate,EndDate,Type,Status,AccountId")] Voucher voucher)
        {
            if (ModelState.IsValid)
            {
                voucher.Id = Guid.NewGuid();
                try
                {
                    await _voucherService.Create(voucher);
                    return RedirectToAction(nameof(Index));
                }
                catch (ArgumentException ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return View(voucher);
        }



        // GET: Vouchers/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var voucher = await _voucherService.GetVoucherById(id);
            if (voucher == null)
            {
                return NotFound();
            }
            return View(voucher);
        }

        // POST: Vouchers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,VoucherCode,Name,DiscountType,DiscountAmount,DiscountPercent,MaxDiscountValue,Stock,Condition,StartDate,EndDate,Type,Status,AccountId")] Voucher voucher)
        {
            if (id != voucher.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _voucherService.Update(voucher);
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await _voucherService.GetVoucherById(id) == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                catch (ArgumentException ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return View(voucher);
        }

        // GET: Vouchers/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var voucher = await _voucherService.GetVoucherById(id);
            if (voucher == null)
            {
                return NotFound();
            }

            return View(voucher);
        }

        // POST: Vouchers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            try
            {
                await _voucherService.Delete(id);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(await _voucherService.GetVoucherById(id));
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
