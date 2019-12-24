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
    public class DictMediaLangTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DictMediaLangTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GlobalDicts/DictMediaLangTypes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DictMediaLangType.Include(d => d.DictStatus);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: GlobalDicts/DictMediaLangTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictMediaLangType = await _context.DictMediaLangType
                .Include(d => d.DictStatus)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dictMediaLangType == null)
            {
                return NotFound();
            }

            return View(dictMediaLangType);
        }

        // GET: GlobalDicts/DictMediaLangTypes/Create
        public IActionResult Create()
        {
            ViewData["DictStatusId"] = new SelectList(_context.DictStatus, "Id", "Name");
            DictMediaLangType model = new DictMediaLangType();
            model.CreateDate = DateTime.Now;
            return View(model);
        }

        // POST: GlobalDicts/DictMediaLangTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NameKyrg,NameRus,CreateDate,DictStatusId,DeactiveDate")] DictMediaLangType dictMediaLangType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dictMediaLangType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DictStatusId"] = new SelectList(_context.DictStatus, "Id", "Name", dictMediaLangType.DictStatusId);
            return View(dictMediaLangType);
        }

        // GET: GlobalDicts/DictMediaLangTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictMediaLangType = await _context.DictMediaLangType.FindAsync(id);
            if (dictMediaLangType == null)
            {
                return NotFound();
            }
            ViewData["DictStatusId"] = new SelectList(_context.DictStatus, "Id", "Name", dictMediaLangType.DictStatusId);
            return View(dictMediaLangType);
        }

        // POST: GlobalDicts/DictMediaLangTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NameKyrg,NameRus,CreateDate,DictStatusId,DeactiveDate")] DictMediaLangType dictMediaLangType)
        {
            if (id != dictMediaLangType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dictMediaLangType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DictMediaLangTypeExists(dictMediaLangType.Id))
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
            ViewData["DictStatusId"] = new SelectList(_context.DictStatus, "Id", "Id", dictMediaLangType.DictStatusId);
            return View(dictMediaLangType);
        }

        // GET: GlobalDicts/DictMediaLangTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictMediaLangType = await _context.DictMediaLangType
                .Include(d => d.DictStatus)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dictMediaLangType == null)
            {
                return NotFound();
            }

            return View(dictMediaLangType);
        }

        // POST: GlobalDicts/DictMediaLangTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dictMediaLangType = await _context.DictMediaLangType.FindAsync(id);
            _context.DictMediaLangType.Remove(dictMediaLangType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DictMediaLangTypeExists(int id)
        {
            return _context.DictMediaLangType.Any(e => e.Id == id);
        }
    }
}
