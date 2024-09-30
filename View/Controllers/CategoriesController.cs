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
    public class CategoriesController : Controller
    {
        private readonly ICategoryServices _categoryServices;

        public CategoriesController(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }

        // GET: Categories
        public async Task<IActionResult> Index()
        {
              return _categoryServices.GetAllCategories() != null ? 
                          View(await _categoryServices.GetAllCategories()) :
                          Problem("Entity set 'Category'  is null.");
        }

        // GET: Categories/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            if (_categoryServices.GetAllCategories() == null)
            {
                return NotFound();
            }

            var category = await _categoryServices.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,Name,Status")] Category category)
        {
            if (ModelState.IsValid)
            {
                category.Id = Guid.NewGuid();
                await _categoryServices.Create(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            if (_categoryServices.GetAllCategories() == null)
            {
                return NotFound();
            }

            var category = await _categoryServices.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Status")] Category category)
        {
            if (id != category.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _categoryServices.Update(category);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_categoryServices.GetAllCategories() == null)
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
            return View(category);
        }

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            if (_categoryServices.GetAllCategories() == null)
            {
                return NotFound();
            }

            var category = await _categoryServices.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_categoryServices.GetAllCategories() == null)
            {
                return Problem("Entity set 'Category'  is null.");
            }

            await _categoryServices.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
