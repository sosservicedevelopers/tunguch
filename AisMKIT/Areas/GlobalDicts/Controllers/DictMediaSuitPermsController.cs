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
    public class DictMediaSuitPermsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DictMediaSuitPermsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GlobalDicts/DictMediaSuitPerms
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DictMediaSuitPerm.Include(d => d.DictStatus);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: GlobalDicts/DictMediaSuitPerms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictMediaSuitPerm = await _context.DictMediaSuitPerm
                .Include(d => d.DictStatus)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dictMediaSuitPerm == null)
            {
                return NotFound();
            }

            return View(dictMediaSuitPerm);
        }

        // GET: GlobalDicts/DictMediaSuitPerms/Create
        public IActionResult Create()
        {
            ViewData["DictStatusId"] = new SelectList(_context.DictStatus, "Id", "Name");
            DictMediaSuitPerm model = new DictMediaSuitPerm();
            model.CreateDate = DateTime.Now;
            return View(model);
        }

        // POST: GlobalDicts/DictMediaSuitPerms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NameKyrg,NameRus,CreateDate,DictStatusId,DeactiveDate")] DictMediaSuitPerm dictMediaSuitPerm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dictMediaSuitPerm);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DictStatusId"] = new SelectList(_context.DictStatus, "Id", "Name", dictMediaSuitPerm.DictStatusId);
            return View(dictMediaSuitPerm);
        }

        // GET: GlobalDicts/DictMediaSuitPerms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictMediaSuitPerm = await _context.DictMediaSuitPerm.FindAsync(id);
            if (dictMediaSuitPerm == null)
            {
                return NotFound();
            }
            ViewData["DictStatusId"] = new SelectList(_context.DictStatus, "Id", "Name", dictMediaSuitPerm.DictStatusId);
            return View(dictMediaSuitPerm);
        }

        // POST: GlobalDicts/DictMediaSuitPerms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NameKyrg,NameRus,CreateDate,DictStatusId,DeactiveDate")] DictMediaSuitPerm dictMediaSuitPerm)
        {
            if (id != dictMediaSuitPerm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dictMediaSuitPerm);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DictMediaSuitPermExists(dictMediaSuitPerm.Id))
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
            ViewData["DictStatusId"] = new SelectList(_context.DictStatus, "Id", "Name", dictMediaSuitPerm.DictStatusId);
            return View(dictMediaSuitPerm);
        }

        // GET: GlobalDicts/DictMediaSuitPerms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictMediaSuitPerm = await _context.DictMediaSuitPerm
                .Include(d => d.DictStatus)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dictMediaSuitPerm == null)
            {
                return NotFound();
            }

            return View(dictMediaSuitPerm);
        }

        // POST: GlobalDicts/DictMediaSuitPerms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dictMediaSuitPerm = await _context.DictMediaSuitPerm.FindAsync(id);
            _context.DictMediaSuitPerm.Remove(dictMediaSuitPerm);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DictMediaSuitPermExists(int id)
        {
            return _context.DictMediaSuitPerm.Any(e => e.Id == id);
        }
    }
}
