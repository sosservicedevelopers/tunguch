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
    public class DictCinemaDurations : Controller
    {
        private readonly ApplicationDbContext _context;

        public DictCinemaDurations(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GlobalDicts/DictCinemaDurations
        public async Task<IActionResult> Index()
        {
            return View(await _context.DictCinemaDuration.ToListAsync());
        }

        // GET: GlobalDicts/DictCinemaDurations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictCinemaDuration = await _context.DictCinemaDuration
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dictCinemaDuration == null)
            {
                return NotFound();
            }

            return View(dictCinemaDuration);
        }

        // GET: GlobalDicts/DictCinemaDurations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GlobalDicts/DictCinemaDurations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] DictCinemaDuration dictCinemaDuration)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dictCinemaDuration);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dictCinemaDuration);
        }

        // GET: GlobalDicts/DictCinemaDurations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictCinemaDuration = await _context.DictCinemaDuration.FindAsync(id);
            if (dictCinemaDuration == null)
            {
                return NotFound();
            }
            return View(dictCinemaDuration);
        }

        // POST: GlobalDicts/DictCinemaDurations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] DictCinemaDuration dictCinemaDuration)
        {
            if (id != dictCinemaDuration.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dictCinemaDuration);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DictCinemaDurationExists(dictCinemaDuration.Id))
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
            return View(dictCinemaDuration);
        }

        // GET: GlobalDicts/DictCinemaDurations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictCinemaDuration = await _context.DictCinemaDuration
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dictCinemaDuration == null)
            {
                return NotFound();
            }

            return View(dictCinemaDuration);
        }

        // POST: GlobalDicts/DictCinemaDurations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dictCinemaDuration = await _context.DictCinemaDuration.FindAsync(id);
            _context.DictCinemaDuration.Remove(dictCinemaDuration);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DictCinemaDurationExists(int id)
        {
            return _context.DictCinemaDuration.Any(e => e.Id == id);
        }
    }
}
