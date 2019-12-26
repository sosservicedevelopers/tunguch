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
    public class DictTypeOfKMMsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DictTypeOfKMMsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GlobalDicts/DictTypeOfKMMs
        public async Task<IActionResult> Index()
        {
            return View(await _context.DictTypeOfKMM.ToListAsync());
        }

        // GET: GlobalDicts/DictTypeOfKMMs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictTypeOfKMM = await _context.DictTypeOfKMM
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dictTypeOfKMM == null)
            {
                return NotFound();
            }

            return View(dictTypeOfKMM);
        }

        // GET: GlobalDicts/DictTypeOfKMMs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GlobalDicts/DictTypeOfKMMs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] DictTypeOfKMM dictTypeOfKMM)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dictTypeOfKMM);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dictTypeOfKMM);
        }

        // GET: GlobalDicts/DictTypeOfKMMs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictTypeOfKMM = await _context.DictTypeOfKMM.FindAsync(id);
            if (dictTypeOfKMM == null)
            {
                return NotFound();
            }
            return View(dictTypeOfKMM);
        }

        // POST: GlobalDicts/DictTypeOfKMMs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] DictTypeOfKMM dictTypeOfKMM)
        {
            if (id != dictTypeOfKMM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dictTypeOfKMM);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DictTypeOfKMMExists(dictTypeOfKMM.Id))
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
            return View(dictTypeOfKMM);
        }

        // GET: GlobalDicts/DictTypeOfKMMs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictTypeOfKMM = await _context.DictTypeOfKMM
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dictTypeOfKMM == null)
            {
                return NotFound();
            }

            return View(dictTypeOfKMM);
        }

        // POST: GlobalDicts/DictTypeOfKMMs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dictTypeOfKMM = await _context.DictTypeOfKMM.FindAsync(id);
            _context.DictTypeOfKMM.Remove(dictTypeOfKMM);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DictTypeOfKMMExists(int id)
        {
            return _context.DictTypeOfKMM.Any(e => e.Id == id);
        }
    }
}
