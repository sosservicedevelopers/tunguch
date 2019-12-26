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
    public class DictUnitOfMeasuresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DictUnitOfMeasuresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GlobalDicts/DictUnitOfMeasures
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DictUnitOfMeasure.Include(d => d.DictStatus);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: GlobalDicts/DictUnitOfMeasures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictUnitOfMeasure = await _context.DictUnitOfMeasure
                .Include(d => d.DictStatus)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dictUnitOfMeasure == null)
            {
                return NotFound();
            }

            return View(dictUnitOfMeasure);
        }

        // GET: GlobalDicts/DictUnitOfMeasures/Create
        public IActionResult Create()
        {
            ViewData["DictStatusId"] = new SelectList(_context.DictStatus, "Id", "Name");
            DictUnitOfMeasure model = new DictUnitOfMeasure();
            model.CreateDate = DateTime.Now;
            model.NameKyrg = "NULL";
            return View(model);
        }

        // POST: GlobalDicts/DictUnitOfMeasures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NameKyrg,NameRus,DictStatusId,CreateDate")] DictUnitOfMeasure dictUnitOfMeasure)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dictUnitOfMeasure);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DictStatusId"] = new SelectList(_context.DictStatus, "Id", "Name", dictUnitOfMeasure.DictStatusId);
            return View(dictUnitOfMeasure);
        }

        // GET: GlobalDicts/DictUnitOfMeasures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictUnitOfMeasure = await _context.DictUnitOfMeasure.FindAsync(id);
            if (dictUnitOfMeasure == null)
            {
                return NotFound();
            }
            ViewData["DictStatusId"] = new SelectList(_context.DictStatus, "Id", "Name", dictUnitOfMeasure.DictStatusId);
            return View(dictUnitOfMeasure);
        }

        // POST: GlobalDicts/DictUnitOfMeasures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NameKyrg,NameRus,DictStatusId,CreateDate")] DictUnitOfMeasure dictUnitOfMeasure)
        {
            if (id != dictUnitOfMeasure.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dictUnitOfMeasure);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DictUnitOfMeasureExists(dictUnitOfMeasure.Id))
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
            ViewData["DictStatusId"] = new SelectList(_context.DictStatus, "Id", "Name", dictUnitOfMeasure.DictStatusId);
            return View(dictUnitOfMeasure);
        }

        // GET: GlobalDicts/DictUnitOfMeasures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictUnitOfMeasure = await _context.DictUnitOfMeasure
                .Include(d => d.DictStatus)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dictUnitOfMeasure == null)
            {
                return NotFound();
            }

            return View(dictUnitOfMeasure);
        }

        // POST: GlobalDicts/DictUnitOfMeasures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dictUnitOfMeasure = await _context.DictUnitOfMeasure.FindAsync(id);
            _context.DictUnitOfMeasure.Remove(dictUnitOfMeasure);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DictUnitOfMeasureExists(int id)
        {
            return _context.DictUnitOfMeasure.Any(e => e.Id == id);
        }
    }
}
