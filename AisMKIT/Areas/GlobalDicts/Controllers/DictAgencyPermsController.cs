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
    public class DictAgencyPermsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DictAgencyPermsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GlobalDicts/DictAgencyPerms
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DictAgencyPerm.Include(d => d.DictStatus);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: GlobalDicts/DictAgencyPerms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictAgencyPerm = await _context.DictAgencyPerm
                .Include(d => d.DictStatus)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dictAgencyPerm == null)
            {
                return NotFound();
            }

            return View(dictAgencyPerm);
        }

        // GET: GlobalDicts/DictAgencyPerms/Create
        public IActionResult Create()
        {
            ViewData["DictStatusId"] = new SelectList(_context.DictStatus, "Id", "Name");
            DictAgencyPerm model = new DictAgencyPerm();
            model.CreateDate = DateTime.Now;
            return View(model);
        }

        // POST: GlobalDicts/DictAgencyPerms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NameKyrg,NameRus,CreateDate,DictStatusId,DeactiveDate")] DictAgencyPerm dictAgencyPerm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dictAgencyPerm);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DictStatusId"] = new SelectList(_context.DictStatus, "Id", "Name", dictAgencyPerm.DictStatusId);
            return View(dictAgencyPerm);
        }

        // GET: GlobalDicts/DictAgencyPerms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictAgencyPerm = await _context.DictAgencyPerm.FindAsync(id);
            if (dictAgencyPerm == null)
            {
                return NotFound();
            }
            ViewData["DictStatusId"] = new SelectList(_context.DictStatus, "Id", "Name", dictAgencyPerm.DictStatusId);
            return View(dictAgencyPerm);
        }

        // POST: GlobalDicts/DictAgencyPerms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NameKyrg,NameRus,CreateDate,DictStatusId,DeactiveDate")] DictAgencyPerm dictAgencyPerm)
        {
            if (id != dictAgencyPerm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dictAgencyPerm);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DictAgencyPermExists(dictAgencyPerm.Id))
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
            ViewData["DictStatusId"] = new SelectList(_context.DictStatus, "Id", "Name", dictAgencyPerm.DictStatusId);
            return View(dictAgencyPerm);
        }

        // GET: GlobalDicts/DictAgencyPerms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictAgencyPerm = await _context.DictAgencyPerm
                .Include(d => d.DictStatus)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dictAgencyPerm == null)
            {
                return NotFound();
            }

            return View(dictAgencyPerm);
        }

        // POST: GlobalDicts/DictAgencyPerms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dictAgencyPerm = await _context.DictAgencyPerm.FindAsync(id);
            _context.DictAgencyPerm.Remove(dictAgencyPerm);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DictAgencyPermExists(int id)
        {
            return _context.DictAgencyPerm.Any(e => e.Id == id);
        }
    }
}
