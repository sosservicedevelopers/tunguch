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
    public class DictDurationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DictDurationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GlobalDicts/DictDurations
        public async Task<IActionResult> Index()
        {
            return View(await _context.DictDuration.ToListAsync());
        }

        // GET: GlobalDicts/DictDurations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictDuration = await _context.DictDuration
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dictDuration == null)
            {
                return NotFound();
            }

            return View(dictDuration);
        }

        // GET: GlobalDicts/DictDurations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GlobalDicts/DictDurations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] DictDuration dictDuration)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dictDuration);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dictDuration);
        }

        // GET: GlobalDicts/DictDurations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictDuration = await _context.DictDuration.FindAsync(id);
            if (dictDuration == null)
            {
                return NotFound();
            }
            return View(dictDuration);
        }

        // POST: GlobalDicts/DictDurations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] DictDuration dictDuration)
        {
            if (id != dictDuration.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dictDuration);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DictDurationExists(dictDuration.Id))
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
            return View(dictDuration);
        }

        // GET: GlobalDicts/DictDurations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictDuration = await _context.DictDuration
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dictDuration == null)
            {
                return NotFound();
            }

            return View(dictDuration);
        }

        // POST: GlobalDicts/DictDurations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dictDuration = await _context.DictDuration.FindAsync(id);
            _context.DictDuration.Remove(dictDuration);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DictDurationExists(int id)
        {
            return _context.DictDuration.Any(e => e.Id == id);
        }
    }
}
