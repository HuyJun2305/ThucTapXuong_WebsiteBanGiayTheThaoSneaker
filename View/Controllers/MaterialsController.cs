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
    public class MaterialsController : Controller
    {
        private readonly IMaterialServices _materialServices;

        public MaterialsController(IMaterialServices materialServices)
        {
            _materialServices = materialServices;
        }

        // GET: Materials
        public async Task<IActionResult> Index()
        {
              return _materialServices.GetAllMaterials() != null ? 
                          View(await _materialServices.GetAllMaterials()) :
                          Problem("Entity set 'Material'  is null.");
        }

        // GET: Materials/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            if (_materialServices.GetAllMaterials() == null)
            {
                return NotFound();
            }

            var material = await _materialServices.GetMaterialById(id);
            if (material == null)
            {
                return NotFound();
            }

            return View(material);
        }

        // GET: Materials/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Materials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Status")] Material material)
        {
            if (ModelState.IsValid)
            {
                material.Id = Guid.NewGuid();
                await _materialServices.Create(material);
                return RedirectToAction(nameof(Index));
            }
            return View(material);
        }

        // GET: Materials/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            if (_materialServices.GetAllMaterials() == null)
            {
                return NotFound();
            }

            var material = await _materialServices.GetMaterialById(id);
            if (material == null)
            {
                return NotFound();
            }
            return View(material);
        }

        // POST: Materials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Status")] Material material)
        {
            if (id != material.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _materialServices.Update(material);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_materialServices.GetAllMaterials() == null)
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
            return View(material);
        }

        // GET: Materials/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            if (_materialServices.GetAllMaterials() == null)
            {
                return NotFound();
            }

            var material = await _materialServices.GetMaterialById(id);
            if (material == null)
            {
                return NotFound();
            }

            return View(material);
        }

        // POST: Materials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_materialServices.GetAllMaterials() == null)
            {
                return Problem("Entity set 'Material'  is null.");
            }

            await _materialServices.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
