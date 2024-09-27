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
    public class SizesController : Controller
    {
        private readonly ISizeServices _sizeServices;

        public SizesController(ISizeServices sizeServices)
        {
            _sizeServices = sizeServices;
        }

        // GET: Sizes
        public async Task<IActionResult> Index()
        {
              return _sizeServices.GetAllSizes() != null ? 
                          View(await _sizeServices.GetAllSizes()) :
                          Problem("Entity set 'ViewContext.Size'  is null.");
        }

        // GET: Sizes/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            if (_sizeServices.GetAllSizes == null)
            {
                return NotFound();
            }

            var size = await _sizeServices.GetSizeById(id);
            if (size == null)
            {
                return NotFound();
            }

            return View(size);
        }

        // GET: Sizes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sizes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Value,Status")] Size size)
        {
            if (ModelState.IsValid)
            {
                size.Id = Guid.NewGuid();
                await _sizeServices.Create(size);
                return RedirectToAction(nameof(Index));
            }
            return View(size);
        }

        // GET: Sizes/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            if (_sizeServices.GetAllSizes() == null)
            {
                return NotFound();
            }

            var size = await _sizeServices.GetSizeById(id);
            if (size == null)
            {
                return NotFound();
            }
            return View(size);
        }

        // POST: Sizes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Value,Status")] Size size)
        {
            if (id != size.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _sizeServices.Update(size);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_sizeServices.GetSizeById(id) == null)
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
            return View(size);
        }

        // GET: Sizes/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            if (_sizeServices.GetAllSizes() == null)
            {
                return NotFound();
            }

            var size = await _sizeServices.GetSizeById(id);
            if (size == null)
            {
                return NotFound();
            }

            return View(size);
        }

        // POST: Sizes/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_sizeServices.GetAllSizes() == null)
            {
                return Problem("Entity set 'Size'  is null.");
            }
            
            await _sizeServices.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
