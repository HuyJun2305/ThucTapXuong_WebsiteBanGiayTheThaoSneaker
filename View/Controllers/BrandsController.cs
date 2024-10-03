using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataProcessing.Models;
using View.Data;
using View.IServices;

namespace View.Controllers
{
    public class BrandsController : Controller
    {
        private readonly IBrandServices _brandServices;

        public BrandsController(IBrandServices context)
        {
            _brandServices = context;
        }

        // GET: Brands
        public async Task<IActionResult> Index()
        {
              return _brandServices.GetAllBrands() != null ? 
                          View(await _brandServices.GetAllBrands()) :
                          Problem("Entity set 'ViewContext.Brand'  is null.");
        }

        // GET: Brands/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            if (_brandServices.GetAllBrands() == null)
            {
                return NotFound();
            }

            var brand = await _brandServices.GetBrandById(id);
            if (brand == null)
            {
                return NotFound();
            }

            return View(brand);
        }

        // GET: Brands/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Brands/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Status")] Brand brand)
        {
            if (ModelState.IsValid)
            {
                brand.Id = Guid.NewGuid();
                await _brandServices.Create(brand);
                return RedirectToAction(nameof(Index));
            }
            return View(brand);
        }

        // GET: Brands/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            if (_brandServices.GetAllBrands() == null)
            {
                return NotFound();
            }

            var brand = await _brandServices.GetBrandById(id);
            if (brand == null)
            {
                return NotFound();
            }
            return View(brand);
        }

        // POST: Brands/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Status")] Brand brand)
        {
            if (id != brand.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _brandServices.Update(brand);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_brandServices.GetAllBrands() == null)
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
            return View(brand);
        }

        // GET: Brands/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            if (_brandServices.GetAllBrands() == null)
            {
                return NotFound();
            }

            var brand = await _brandServices.GetBrandById(id);
            if (brand == null)
            {
                return NotFound();
            }

            return View(brand);
        }

        // POST: Brands/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_brandServices.GetAllBrands() == null)
            {
                return Problem("Entity set 'Brand'  is null.");
            }

            await _brandServices.Delete(id);

			return RedirectToAction(nameof(Index));
        }
    }
}
