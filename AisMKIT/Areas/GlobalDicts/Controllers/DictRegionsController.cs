using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AisMKIT.Data;
using AisMKIT.Models;

namespace AisMKIT.Areas.GlobalDicts.Controllers
{
    [Area("GlobalDicts")]
    public class DictRegionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DictRegionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GlobalDicts/DictRegions
        public async Task<IActionResult> Index()
        {
            return View(await _context.DictRegion.ToListAsync());
        }

        // GET: GlobalDicts/DictRegions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictRegion = await _context.DictRegion
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dictRegion == null)
            {
                return NotFound();
            }

            return View(dictRegion);
        }

        // GET: GlobalDicts/DictRegions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GlobalDicts/DictRegions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NameKyrg,NameRus")] DictRegion dictRegion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dictRegion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dictRegion);
        }

        // GET: GlobalDicts/DictRegions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictRegion = await _context.DictRegion.FindAsync(id);
            if (dictRegion == null)
            {
                return NotFound();
            }
            return View(dictRegion);
        }

        // POST: GlobalDicts/DictRegions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NameKyrg,NameRus")] DictRegion dictRegion)
        {
            if (id != dictRegion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dictRegion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DictRegionExists(dictRegion.Id))
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
            return View(dictRegion);
        }

        // GET: GlobalDicts/DictRegions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictRegion = await _context.DictRegion
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dictRegion == null)
            {
                return NotFound();
            }

            return View(dictRegion);
        }

        // POST: GlobalDicts/DictRegions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dictRegion = await _context.DictRegion.FindAsync(id);
            _context.DictRegion.Remove(dictRegion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DictRegionExists(int id)
        {
            return _context.DictRegion.Any(e => e.Id == id);
        }
    }
}
