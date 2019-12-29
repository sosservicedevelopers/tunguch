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
    public class DictAwardsPositionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DictAwardsPositionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GlobalDicts/DictAwardsPositions
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DictAwardsPosition.Include(d => d.DictStatus);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: GlobalDicts/DictAwardsPositions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictAwardsPosition = await _context.DictAwardsPosition
                .Include(d => d.DictStatus)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dictAwardsPosition == null)
            {
                return NotFound();
            }

            return View(dictAwardsPosition);
        }

        // GET: GlobalDicts/DictAwardsPositions/Create
        public IActionResult Create()
        {
            ViewData["DictStatusId"] = new SelectList(_context.DictStatus, "Id", "Name");
            DictAwardsPosition model = new DictAwardsPosition();
            model.CreateDate = DateTime.Now;
            model.NameKyrg = "NULL";
            return View(model);
        }

        // POST: GlobalDicts/DictAwardsPositions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NameKyrg,NameRus,DictStatusId,CreateDate")] DictAwardsPosition dictAwardsPosition)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dictAwardsPosition);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DictStatusId"] = new SelectList(_context.DictStatus, "Id", "Name", dictAwardsPosition.DictStatusId);
            return View(dictAwardsPosition);
        }

        // GET: GlobalDicts/DictAwardsPositions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictAwardsPosition = await _context.DictAwardsPosition.FindAsync(id);
            if (dictAwardsPosition == null)
            {
                return NotFound();
            }
            ViewData["DictStatusId"] = new SelectList(_context.DictStatus, "Id", "Name", dictAwardsPosition.DictStatusId);
            return View(dictAwardsPosition);
        }

        // POST: GlobalDicts/DictAwardsPositions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NameKyrg,NameRus,DictStatusId,CreateDate")] DictAwardsPosition dictAwardsPosition)
        {
            if (id != dictAwardsPosition.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dictAwardsPosition);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DictAwardsPositionExists(dictAwardsPosition.Id))
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
            ViewData["DictStatusId"] = new SelectList(_context.DictStatus, "Id", "Name", dictAwardsPosition.DictStatusId);
            return View(dictAwardsPosition);
        }

        // GET: GlobalDicts/DictAwardsPositions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictAwardsPosition = await _context.DictAwardsPosition
                .Include(d => d.DictStatus)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dictAwardsPosition == null)
            {
                return NotFound();
            }

            return View(dictAwardsPosition);
        }

        // POST: GlobalDicts/DictAwardsPositions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dictAwardsPosition = await _context.DictAwardsPosition.FindAsync(id);
            _context.DictAwardsPosition.Remove(dictAwardsPosition);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DictAwardsPositionExists(int id)
        {
            return _context.DictAwardsPosition.Any(e => e.Id == id);
        }
    }
}
