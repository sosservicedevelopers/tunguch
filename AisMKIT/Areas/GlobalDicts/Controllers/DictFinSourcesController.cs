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
    public class DictFinSourcesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DictFinSourcesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GlobalDicts/DictFinSources
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DictFinSource.Include(d => d.DictStatus);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: GlobalDicts/DictFinSources/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictFinSource = await _context.DictFinSource
                .Include(d => d.DictStatus)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dictFinSource == null)
            {
                return NotFound();
            }

            return View(dictFinSource);
        }

        // GET: GlobalDicts/DictFinSources/Create
        public IActionResult Create()
        {
            ViewData["DictStatusId"] = new SelectList(_context.DictStatus, "Id", "Name");
            DictFinSource model = new DictFinSource();
            model.CreateDate = DateTime.Now;
            return View(model);
        }

        // POST: GlobalDicts/DictFinSources/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NameKyrg,NameRus,CreateDate,StatusForDictId,DeactiveDate")] DictFinSource dictFinSource)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dictFinSource);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DictStatusId"] = new SelectList(_context.DictStatus, "Id", "Name", dictFinSource.DictStatusId);
            return View(dictFinSource);
        }

        // GET: GlobalDicts/DictFinSources/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictFinSource = await _context.DictFinSource.FindAsync(id);
            if (dictFinSource == null)
            {
                return NotFound();
            }
            ViewData["DictStatusId"] = new SelectList(_context.DictStatus, "Id", "Name", dictFinSource.DictStatusId);
            return View(dictFinSource);
        }

        // POST: GlobalDicts/DictFinSources/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NameKyrg,NameRus,CreateDate,StatusForDictId,DeactiveDate")] DictFinSource dictFinSource)
        {
            if (id != dictFinSource.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dictFinSource);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DictFinSourceExists(dictFinSource.Id))
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
            ViewData["DictStatusId"] = new SelectList(_context.DictStatus, "Id", "Name", dictFinSource.DictStatusId);
            return View(dictFinSource);
        }

        // GET: GlobalDicts/DictFinSources/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictFinSource = await _context.DictFinSource
                .Include(d => d.DictStatus)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dictFinSource == null)
            {
                return NotFound();
            }

            return View(dictFinSource);
        }

        // POST: GlobalDicts/DictFinSources/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dictFinSource = await _context.DictFinSource.FindAsync(id);
            _context.DictFinSource.Remove(dictFinSource);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DictFinSourceExists(int id)
        {
            return _context.DictFinSource.Any(e => e.Id == id);
        }
    }
}
