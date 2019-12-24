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
    public class DictDistrictsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DictDistrictsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GlobalDicts/DictDistricts
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DictDistrict.Include(d => d.DictRegion);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: GlobalDicts/DictDistricts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictDistrict = await _context.DictDistrict
                .Include(d => d.DictRegion)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dictDistrict == null)
            {
                return NotFound();
            }

            return View(dictDistrict);
        }

        // GET: GlobalDicts/DictDistricts/Create
        public IActionResult Create()
        {
            ViewData["DictRegionId"] = new SelectList(_context.DictRegion, "Id", "NameRus");
            return View();
        }

        // POST: GlobalDicts/DictDistricts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NameKyrg,NameRus,City,DictRegionId")] DictDistrict dictDistrict)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dictDistrict);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DictRegionId"] = new SelectList(_context.DictRegion, "Id", "NameRus", dictDistrict.DictRegionId);
            return View(dictDistrict);
        }

        // GET: GlobalDicts/DictDistricts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictDistrict = await _context.DictDistrict.FindAsync(id);
            if (dictDistrict == null)
            {
                return NotFound();
            }
            ViewData["DictRegionId"] = new SelectList(_context.DictRegion, "Id", "NameRus", dictDistrict.DictRegionId);
            return View(dictDistrict);
        }

        // POST: GlobalDicts/DictDistricts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NameKyrg,NameRus,City,DictRegionId")] DictDistrict dictDistrict)
        {
            if (id != dictDistrict.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dictDistrict);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DictDistrictExists(dictDistrict.Id))
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
            ViewData["DictRegionId"] = new SelectList(_context.DictRegion, "Id", "NameRus", dictDistrict.DictRegionId);
            return View(dictDistrict);
        }

        // GET: GlobalDicts/DictDistricts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictDistrict = await _context.DictDistrict
                .Include(d => d.DictRegion)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dictDistrict == null)
            {
                return NotFound();
            }

            return View(dictDistrict);
        }

        // POST: GlobalDicts/DictDistricts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dictDistrict = await _context.DictDistrict.FindAsync(id);
            _context.DictDistrict.Remove(dictDistrict);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DictDistrictExists(int id)
        {
            return _context.DictDistrict.Any(e => e.Id == id);
        }
    }
}
