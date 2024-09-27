using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataProcessing.Models;
using View.IServices;

namespace View.Controllers
{
    public class ColorsController : Controller
    {
        private readonly IColorServices _colorServices;

        public ColorsController(IColorServices colorServices)
        {
            _colorServices = colorServices;
        }

        // GET: Colors
        public async Task<IActionResult> Index()
        {
            return _colorServices.GetAllColors() != null ?
                        View(await _colorServices.GetAllColors()) :
                        Problem("Entity set 'ViewContext.Color'  is null.");
        }

        // GET: Colors/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            if (_colorServices.GetAllColors() == null)
            {
                return NotFound();
            }

            var color = await _colorServices.GetColorById(id);
            if (color == null)
            {
                return NotFound();
            }

            return View(color);
        }

        // GET: Colors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Colors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,Name,HEX,Status")] Color color)
        {
            if (ModelState.IsValid)
            {
                color.Id = Guid.NewGuid();
                await _colorServices.Create(color);
                return RedirectToAction(nameof(Index));
            }
            return View(color);
        }

        // GET: Colors/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            if (_colorServices.GetAllColors() == null)
            {
                return NotFound();
            }

            var color = await _colorServices.GetColorById(id);
            if (color == null)
            {
                return NotFound();
            }
            return View(color);
        }

        // POST: Colors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,HEX,Status")] Color color)
        {
            if (id != color.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _colorServices.Update(color);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_colorServices.GetColorById(id).Result == null)
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
            return View(color);
        }

        // GET: Colors/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            if (_colorServices.GetColorById(id) == null)
            {
                return NotFound();
            }

            var color = await _colorServices.GetColorById(id);
            if (color == null)
            {
                return NotFound();
            }

            return View(color);
        }

        // POST: Colors/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_colorServices.GetAllColors() == null)
            {
                return Problem("Entity set 'ViewContext.Color'  is null.");
            }

            await _colorServices.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
