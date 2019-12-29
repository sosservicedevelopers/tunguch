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
    public class DictAwardsReasonsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DictAwardsReasonsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GlobalDicts/DictAwardsReasons
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DictAwardsReason.Include(d => d.DictStatus);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: GlobalDicts/DictAwardsReasons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictAwardsReason = await _context.DictAwardsReason
                .Include(d => d.DictStatus)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dictAwardsReason == null)
            {
                return NotFound();
            }

            return View(dictAwardsReason);
        }

        // GET: GlobalDicts/DictAwardsReasons/Create
        public IActionResult Create()
        {
            ViewData["DictStatusId"] = new SelectList(_context.DictStatus, "Id", "Name");
            DictAwardsReason model = new DictAwardsReason();
            model.CreateDate = DateTime.Now;
            model.NameKyrg = "NULL";
            return View(model);
        }

        // POST: GlobalDicts/DictAwardsReasons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NameKyrg,NameRus,DictStatusId,CreateDate")] DictAwardsReason dictAwardsReason)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dictAwardsReason);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DictStatusId"] = new SelectList(_context.DictStatus, "Id", "Name", dictAwardsReason.DictStatusId);
            return View(dictAwardsReason);
        }

        // GET: GlobalDicts/DictAwardsReasons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictAwardsReason = await _context.DictAwardsReason.FindAsync(id);
            if (dictAwardsReason == null)
            {
                return NotFound();
            }
            ViewData["DictStatusId"] = new SelectList(_context.DictStatus, "Id", "Name", dictAwardsReason.DictStatusId);
            return View(dictAwardsReason);
        }

        // POST: GlobalDicts/DictAwardsReasons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NameKyrg,NameRus,DictStatusId,CreateDate")] DictAwardsReason dictAwardsReason)
        {
            if (id != dictAwardsReason.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dictAwardsReason);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DictAwardsReasonExists(dictAwardsReason.Id))
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
            ViewData["DictStatusId"] = new SelectList(_context.DictStatus, "Id", "Name", dictAwardsReason.DictStatusId);
            return View(dictAwardsReason);
        }

        // GET: GlobalDicts/DictAwardsReasons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictAwardsReason = await _context.DictAwardsReason
                .Include(d => d.DictStatus)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dictAwardsReason == null)
            {
                return NotFound();
            }

            return View(dictAwardsReason);
        }

        // POST: GlobalDicts/DictAwardsReasons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dictAwardsReason = await _context.DictAwardsReason.FindAsync(id);
            _context.DictAwardsReason.Remove(dictAwardsReason);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DictAwardsReasonExists(int id)
        {
            return _context.DictAwardsReason.Any(e => e.Id == id);
        }
    }
}
