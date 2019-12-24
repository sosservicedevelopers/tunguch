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
    public class DictControlTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DictControlTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GlobalDicts/DictControlTypes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DictControlType.Include(d => d.DictStatus);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: GlobalDicts/DictControlTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictControlType = await _context.DictControlType
                .Include(d => d.DictStatus)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dictControlType == null)
            {
                return NotFound();
            }

            return View(dictControlType);
        }

        // GET: GlobalDicts/DictControlTypes/Create
        public IActionResult Create()
        {
            ViewData["DictStatusId"] = new SelectList(_context.DictStatus, "Id", "Name");
            DictControlType model = new DictControlType();
            model.CreateDate = DateTime.Now;
            return View(model);
        }

        // POST: GlobalDicts/DictControlTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NameKyrg,NameRus,CreateDate,DictStatusId,DeactiveDate")] DictControlType dictControlType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dictControlType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DictStatusId"] = new SelectList(_context.DictStatus, "Id", "Name", dictControlType.DictStatusId);
            return View(dictControlType);
        }

        // GET: GlobalDicts/DictControlTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictControlType = await _context.DictControlType.FindAsync(id);
            if (dictControlType == null)
            {
                return NotFound();
            }
            ViewData["DictStatusId"] = new SelectList(_context.DictStatus, "Id", "Name", dictControlType.DictStatusId);
            return View(dictControlType);
        }

        // POST: GlobalDicts/DictControlTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NameKyrg,NameRus,CreateDate,DictStatusId,DeactiveDate")] DictControlType dictControlType)
        {
            if (id != dictControlType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dictControlType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DictControlTypeExists(dictControlType.Id))
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
            ViewData["DictStatusId"] = new SelectList(_context.DictStatus, "Id", "Name", dictControlType.DictStatusId);
            return View(dictControlType);
        }

        // GET: GlobalDicts/DictControlTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictControlType = await _context.DictControlType
                .Include(d => d.DictStatus)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dictControlType == null)
            {
                return NotFound();
            }

            return View(dictControlType);
        }

        // POST: GlobalDicts/DictControlTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dictControlType = await _context.DictControlType.FindAsync(id);
            _context.DictControlType.Remove(dictControlType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DictControlTypeExists(int id)
        {
            return _context.DictControlType.Any(e => e.Id == id);
        }
    }
}
