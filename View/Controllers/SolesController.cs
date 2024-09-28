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
    public class SolesController : Controller
    {
        private readonly ISoleServices _soleServices;

        public SolesController(ISoleServices soleServices)
        {
            _soleServices = soleServices;
        }

        // GET: Soles
        public async Task<IActionResult> Index()
        {
              return _soleServices.GetAllSoles() != null ? 
                          View(await _soleServices.GetAllSoles()) :
                          Problem("Entity set 'Sole'  is null.");
        }

        // GET: Soles/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            if (_soleServices.GetSoleById(id) == null)
            {
                return NotFound();
            }

            var sole = await _soleServices.GetSoleById(id);
            return View(sole);
        }

        // GET: Soles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Soles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,TypeName,Status")] Sole sole)
        {
            if (ModelState.IsValid)
            {
                await _soleServices.Create(sole);
                return RedirectToAction(nameof(Index));
            }
            return View(sole);
        }

        // GET: Soles/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
			if (_soleServices.GetSoleById(id) == null)
			{
				return NotFound();
			}

			var sole = await _soleServices.GetSoleById(id);
			return View(sole);
        }

        // POST: Soles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,TypeName,Status")] Sole sole)
        {
            if (id != sole.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _soleServices.Update(sole);
                return RedirectToAction(nameof(Index));
            }
            return View(sole);
        }

        // GET: Soles/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
			if (_soleServices.GetSoleById(id) == null)
			{
				return NotFound();
			}

			var sole = await _soleServices.GetSoleById(id);
			return View(sole);
        }

        // POST: Soles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_soleServices.GetAllSoles() == null)
            {
                return Problem("Entity set 'Sole' is null.");
            }
            await _soleServices.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
