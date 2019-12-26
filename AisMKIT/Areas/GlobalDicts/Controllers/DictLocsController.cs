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
    public class DictLocsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DictLocsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GlobalDicts/DictLocs
        public async Task<IActionResult> Index()
        {
            return View(await _context.DictLoc.ToListAsync());
        }

        // GET: GlobalDicts/DictLocs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictLoc = await _context.DictLoc
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dictLoc == null)
            {
                return NotFound();
            }

            return View(dictLoc);
        }

        // GET: GlobalDicts/DictLocs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GlobalDicts/DictLocs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] DictLoc dictLoc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dictLoc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dictLoc);
        }

        // GET: GlobalDicts/DictLocs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictLoc = await _context.DictLoc.FindAsync(id);
            if (dictLoc == null)
            {
                return NotFound();
            }
            return View(dictLoc);
        }

        // POST: GlobalDicts/DictLocs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] DictLoc dictLoc)
        {
            if (id != dictLoc.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dictLoc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DictLocExists(dictLoc.Id))
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
            return View(dictLoc);
        }

        // GET: GlobalDicts/DictLocs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictLoc = await _context.DictLoc
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dictLoc == null)
            {
                return NotFound();
            }

            return View(dictLoc);
        }

        // POST: GlobalDicts/DictLocs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dictLoc = await _context.DictLoc.FindAsync(id);
            _context.DictLoc.Remove(dictLoc);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DictLocExists(int id)
        {
            return _context.DictLoc.Any(e => e.Id == id);
        }
    }
}
