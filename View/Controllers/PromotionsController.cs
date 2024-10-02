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
using View.Servicecs;

namespace View.Controllers
{
    public class PromotionsController : Controller
    {
        private readonly IPromotionServices _PromotionSer;

        public PromotionsController(IPromotionServices promotionSer)
        {
            _PromotionSer = promotionSer;
        }



        // GET: Promotions
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var viewContext = _PromotionSer.GetAllPromotion().Result;
            if (viewContext == null) return View("'Promotion is null!'");
            return View(viewContext.ToList());
        }

        //  GET: Promotions/Details/5
       
        public async Task<IActionResult> Details(Guid id)
        {
            var promotion = await _PromotionSer.GetPromotionById(id);
            if (promotion == null)
            {
                return NotFound();
            }
            return View(promotion);
        }

        // GET: Promotions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Promotions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,DiscountValue,StartDate,EndDate,Status")] Promotion promotion)
        {
            if (ModelState.IsValid)
            {
                await _PromotionSer.Create(promotion);
                return RedirectToAction(nameof(Index));
            }
            return View(promotion);
        }

        // GET: Promotions/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {

            var promotion = await _PromotionSer.GetPromotionById(id);
            if (promotion == null)
            {
                return NotFound();
            }
            return View(promotion);
        }

        // POST: Promotions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,DiscountValue,StartDate,EndDate,Status")] Promotion promotion)
        {
            if (id != promotion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _PromotionSer.Update(promotion);
                return RedirectToAction(nameof(Index));
            }
            return View(promotion);
        }

        // GET: Promotions/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {


            var promotion = await _PromotionSer.GetPromotionById(id);
            if (promotion == null)
            {
                return NotFound();
            }
           

            return View(promotion);
        }

        // POST: Promotions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {

            
           await _PromotionSer.Delete(id);
            return RedirectToAction(nameof(Index));
        }


    }
}
