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
    public class DictStateAwardsTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DictStateAwardsTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GlobalDicts/DictStateAwardsTypes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DictStateAwardsType.Include(d => d.DictStatus);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: GlobalDicts/DictStateAwardsTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictStateAwardsType = await _context.DictStateAwardsType
                .Include(d => d.DictStatus)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dictStateAwardsType == null)
            {
                return NotFound();
            }

            return View(dictStateAwardsType);
        }

        // GET: GlobalDicts/DictStateAwardsTypes/Create
        public IActionResult Create()
        {
            ViewData["DictStatusId"] = new SelectList(_context.DictStatus, "Id", "Name");
            DictStateAwardsType model = new DictStateAwardsType();
            model.CreateDate = DateTime.Now;
            model.NameKyrg = "NULL";
            return View(model);
        }

        // POST: GlobalDicts/DictStateAwardsTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NameKyrg,NameRus,DictStatusId,CreateDate")] DictStateAwardsType dictStateAwardsType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dictStateAwardsType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DictStatusId"] = new SelectList(_context.DictStatus, "Id", "Name", dictStateAwardsType.DictStatusId);
            return View(dictStateAwardsType);
        }

        // GET: GlobalDicts/DictStateAwardsTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictStateAwardsType = await _context.DictStateAwardsType.FindAsync(id);
            if (dictStateAwardsType == null)
            {
                return NotFound();
            }
            ViewData["DictStatusId"] = new SelectList(_context.DictStatus, "Id", "Name", dictStateAwardsType.DictStatusId);
            return View(dictStateAwardsType);
        }

        // POST: GlobalDicts/DictStateAwardsTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NameKyrg,NameRus,DictStatusId,CreateDate")] DictStateAwardsType dictStateAwardsType)
        {
            if (id != dictStateAwardsType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dictStateAwardsType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DictStateAwardsTypeExists(dictStateAwardsType.Id))
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
            ViewData["DictStatusId"] = new SelectList(_context.DictStatus, "Id", "Name", dictStateAwardsType.DictStatusId);
            return View(dictStateAwardsType);
        }

        // GET: GlobalDicts/DictStateAwardsTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictStateAwardsType = await _context.DictStateAwardsType
                .Include(d => d.DictStatus)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dictStateAwardsType == null)
            {
                return NotFound();
            }

            return View(dictStateAwardsType);
        }

        // POST: GlobalDicts/DictStateAwardsTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dictStateAwardsType = await _context.DictStateAwardsType.FindAsync(id);
            _context.DictStateAwardsType.Remove(dictStateAwardsType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DictStateAwardsTypeExists(int id)
        {
            return _context.DictStateAwardsType.Any(e => e.Id == id);
        }
    }
}
