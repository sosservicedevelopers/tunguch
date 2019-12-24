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
    public class DictMediaFreqReleasesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DictMediaFreqReleasesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GlobalDicts/DictMediaFreqReleases
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DictMediaFreqRelease.Include(d => d.DictStatus);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: GlobalDicts/DictMediaFreqReleases/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictMediaFreqRelease = await _context.DictMediaFreqRelease
                .Include(d => d.DictStatus)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dictMediaFreqRelease == null)
            {
                return NotFound();
            }

            return View(dictMediaFreqRelease);
        }

        // GET: GlobalDicts/DictMediaFreqReleases/Create
        public IActionResult Create()
        {
            ViewData["DictStatusId"] = new SelectList(_context.DictStatus, "Id", "Name");
            DictMediaFreqRelease model = new DictMediaFreqRelease();
            model.CreateDate = DateTime.Now;
            return View(model);
        }

        // POST: GlobalDicts/DictMediaFreqReleases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NameKyrg,NameRus,CreateDate,DictStatusId,DeactiveDate")] DictMediaFreqRelease dictMediaFreqRelease)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dictMediaFreqRelease);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DictStatusId"] = new SelectList(_context.DictStatus, "Id", "Name", dictMediaFreqRelease.DictStatusId);
            return View(dictMediaFreqRelease);
        }

        // GET: GlobalDicts/DictMediaFreqReleases/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictMediaFreqRelease = await _context.DictMediaFreqRelease.FindAsync(id);
            if (dictMediaFreqRelease == null)
            {
                return NotFound();
            }
            ViewData["DictStatusId"] = new SelectList(_context.DictStatus, "Id", "Name", dictMediaFreqRelease.DictStatusId);
            return View(dictMediaFreqRelease);
        }

        // POST: GlobalDicts/DictMediaFreqReleases/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NameKyrg,NameRus,CreateDate,DictStatusId,DeactiveDate")] DictMediaFreqRelease dictMediaFreqRelease)
        {
            if (id != dictMediaFreqRelease.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dictMediaFreqRelease);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DictMediaFreqReleaseExists(dictMediaFreqRelease.Id))
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
            ViewData["DictStatusId"] = new SelectList(_context.DictStatus, "Id", "Name", dictMediaFreqRelease.DictStatusId);
            return View(dictMediaFreqRelease);
        }

        // GET: GlobalDicts/DictMediaFreqReleases/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictMediaFreqRelease = await _context.DictMediaFreqRelease
                .Include(d => d.DictStatus)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dictMediaFreqRelease == null)
            {
                return NotFound();
            }

            return View(dictMediaFreqRelease);
        }

        // POST: GlobalDicts/DictMediaFreqReleases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dictMediaFreqRelease = await _context.DictMediaFreqRelease.FindAsync(id);
            _context.DictMediaFreqRelease.Remove(dictMediaFreqRelease);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DictMediaFreqReleaseExists(int id)
        {
            return _context.DictMediaFreqRelease.Any(e => e.Id == id);
        }
    }
}
