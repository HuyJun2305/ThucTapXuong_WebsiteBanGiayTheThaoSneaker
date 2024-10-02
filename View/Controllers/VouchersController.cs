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
        public async Task<IActionResult> Create([Bind("Id,VoucherCode,Name,VoucherType,DiscountAmount,DiscountPercent,Condittion,Stock,StartDate,EndDate,Status,AccountId")] Voucher voucher)
        {
            if (ModelState.IsValid)
            {
                voucher.Id = Guid.NewGuid();
                await _voucherService.Create(voucher);
                return RedirectToAction(nameof(Index));
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
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,VoucherCode,Name,VoucherType,DiscountAmount,DiscountPercent,Condittion,Stock,StartDate,EndDate,Status,AccountId")] Voucher voucher)
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
                return RedirectToAction(nameof(Index));
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
            await _voucherService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
