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
    public class DictRentObjectTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DictRentObjectTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GlobalDicts/DictRentObjectTypes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DictRentObjectType.Include(d => d.DictStatus).Include(d => d.DictUnitOfMeasure);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: GlobalDicts/DictRentObjectTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictRentObjectType = await _context.DictRentObjectType
                .Include(d => d.DictStatus)
                .Include(d => d.DictUnitOfMeasure)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dictRentObjectType == null)
            {
                return NotFound();
            }

            return View(dictRentObjectType);
        }

        // GET: GlobalDicts/DictRentObjectTypes/Create
        public IActionResult Create()
        {
            ViewData["DictStatusId"] = new SelectList(_context.DictStatus, "Id", "Name");
            ViewData["DictUnitOfMeasureId"] = new SelectList(_context.DictUnitOfMeasure, "Id", "NameRus");
            DictRentObjectType model = new DictRentObjectType();
            model.CreateDate = DateTime.Now;
            model.NameKyrg = "NULL";
            return View(model);
        }

        // POST: GlobalDicts/DictRentObjectTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NameKyrg,NameRus,DictUnitOfMeasureId,DictStatusId,CreateDate")] DictRentObjectType dictRentObjectType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dictRentObjectType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DictStatusId"] = new SelectList(_context.DictStatus, "Id", "Name", dictRentObjectType.DictStatusId);
            ViewData["DictUnitOfMeasureId"] = new SelectList(_context.DictUnitOfMeasure, "Id", "NameRus", dictRentObjectType.DictUnitOfMeasureId);
            return View(dictRentObjectType);
        }

        // GET: GlobalDicts/DictRentObjectTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictRentObjectType = await _context.DictRentObjectType.FindAsync(id);
            if (dictRentObjectType == null)
            {
                return NotFound();
            }
            ViewData["DictStatusId"] = new SelectList(_context.DictStatus, "Id", "Name", dictRentObjectType.DictStatusId);
            ViewData["DictUnitOfMeasureId"] = new SelectList(_context.DictUnitOfMeasure, "Id", "NameRus", dictRentObjectType.DictUnitOfMeasureId);
            return View(dictRentObjectType);
        }

        // POST: GlobalDicts/DictRentObjectTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NameKyrg,NameRus,DictUnitOfMeasureId,DictStatusId,CreateDate")] DictRentObjectType dictRentObjectType)
        {
            if (id != dictRentObjectType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dictRentObjectType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DictRentObjectTypeExists(dictRentObjectType.Id))
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
            ViewData["DictStatusId"] = new SelectList(_context.DictStatus, "Id", "Name", dictRentObjectType.DictStatusId);
            ViewData["DictUnitOfMeasureId"] = new SelectList(_context.DictUnitOfMeasure, "Id", "NameRus", dictRentObjectType.DictUnitOfMeasureId);
            return View(dictRentObjectType);
        }

        // GET: GlobalDicts/DictRentObjectTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictRentObjectType = await _context.DictRentObjectType
                .Include(d => d.DictStatus)
                .Include(d => d.DictUnitOfMeasure)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dictRentObjectType == null)
            {
                return NotFound();
            }

            return View(dictRentObjectType);
        }

        // POST: GlobalDicts/DictRentObjectTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dictRentObjectType = await _context.DictRentObjectType.FindAsync(id);
            _context.DictRentObjectType.Remove(dictRentObjectType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DictRentObjectTypeExists(int id)
        {
            return _context.DictRentObjectType.Any(e => e.Id == id);
        }
    }
}
