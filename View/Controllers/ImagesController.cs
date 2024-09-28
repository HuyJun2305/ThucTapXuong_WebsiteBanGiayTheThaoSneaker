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
    public class ImagesController : Controller
    {
        private readonly IImageServices _imageServices;
        private readonly IColorServices _colorServices;

        public ImagesController(IImageServices context, IColorServices colorServices)
        {
            _imageServices = context;
            _colorServices = colorServices;
        }

        // GET: Images
        public async Task<IActionResult> Index()
        {
            var viewContext = _imageServices.GetAllImages().Result;
            return View(viewContext.ToList());
        }

        // GET: Images/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            if (_imageServices.GetAllImages() == null)
            {
                return NotFound();
            }

            var image = await _imageServices.GetImageById(id);
            if (image == null)
            {
                return NotFound();
            }

            return View(image);
        }

        // GET: Images/Create
        public IActionResult Create()
        {
            ViewData["ColorId"] = new SelectList(_colorServices.GetAllColors().Result.Where(c => c.Status == true), "Id", "HEX");
            return View();
        }

        // POST: Images/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,URL,ColorId")] Image image)
        {
            if (image.URL != null)
            {
                image.Id = Guid.NewGuid();
                await _imageServices.Create(image);
                return RedirectToAction(nameof(Index));
            }
            ViewData["ColorId"] = new SelectList(_colorServices.GetAllColors().Result.Where(c => c.Status == true), "Id", "HEX", image.ColorId);
            return View(image);
        }

        // GET: Images/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            if (_imageServices.GetAllImages() == null)
            {
                return NotFound();
            }

            var image = await _imageServices.GetImageById(id);
            if (image == null)
            {
                return NotFound();
            }
            ViewData["ColorId"] = new SelectList(_colorServices.GetAllColors().Result.Where(c => c.Status == true), "Id", "HEX", image.ColorId);
            return View(image);
        }

        // POST: Images/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,URL,ColorId")] Image image)
        {
            if (id != image.Id)
            {
                return NotFound();
            }

            if (image.URL != null)
            {
                try
                {
                    await _imageServices.Update(image);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_imageServices.GetImageById(id) == null)
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
            ViewData["ColorId"] = new SelectList(_colorServices.GetAllColors().Result.Where(c => c.Status == true), "Id", "HEX", image.ColorId);
            return View(image);
        }

        // GET: Images/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            if (_imageServices.GetAllImages() == null)
            {
                return NotFound();
            }

            var image = await _imageServices.GetImageById(id);
            if (image == null)
            {
                return NotFound();
            }

            return View(image);
        }

        // POST: Images/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_imageServices.GetAllImages() == null)
            {
                return Problem("Entity set 'Image'  is null.");
            }
            await _imageServices.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
