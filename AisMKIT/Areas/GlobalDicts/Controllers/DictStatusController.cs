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
    public class DictStatusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DictStatusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GlobalDicts/DictStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.DictStatus.ToListAsync());
        }

        // GET: GlobalDicts/DictStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictStatus = await _context.DictStatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dictStatus == null)
            {
                return NotFound();
            }

            return View(dictStatus);
        }

        // GET: GlobalDicts/DictStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GlobalDicts/DictStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] DictStatus dictStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dictStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dictStatus);
        }

        // GET: GlobalDicts/DictStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictStatus = await _context.DictStatus.FindAsync(id);
            if (dictStatus == null)
            {
                return NotFound();
            }
            return View(dictStatus);
        }

        // POST: GlobalDicts/DictStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] DictStatus dictStatus)
        {
            if (id != dictStatus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dictStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DictStatusExists(dictStatus.Id))
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
            return View(dictStatus);
        }

        // GET: GlobalDicts/DictStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictStatus = await _context.DictStatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dictStatus == null)
            {
                return NotFound();
            }

            return View(dictStatus);
        }

        // POST: GlobalDicts/DictStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dictStatus = await _context.DictStatus.FindAsync(id);
            _context.DictStatus.Remove(dictStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DictStatusExists(int id)
        {
            return _context.DictStatus.Any(e => e.Id == id);
        }
    }
}
