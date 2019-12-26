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
    public class DictCultAndArtTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DictCultAndArtTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GlobalDicts/DictCultAndArtTypes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DictCultAndArtType.Include(d => d.DictStatus);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: GlobalDicts/DictCultAndArtTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictCultAndArtType = await _context.DictCultAndArtType
                .Include(d => d.DictStatus)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dictCultAndArtType == null)
            {
                return NotFound();
            }

            return View(dictCultAndArtType);
        }

        // GET: GlobalDicts/DictCultAndArtTypes/Create
        public IActionResult Create()
        {
            ViewData["DictStatusId"] = new SelectList(_context.DictStatus, "Id", "Id");
            return View();
        }

        // POST: GlobalDicts/DictCultAndArtTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NameKyrg,NameRus,DictStatusId,CreateDate")] DictCultAndArtType dictCultAndArtType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dictCultAndArtType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DictStatusId"] = new SelectList(_context.DictStatus, "Id", "Id", dictCultAndArtType.DictStatusId);
            return View(dictCultAndArtType);
        }

        // GET: GlobalDicts/DictCultAndArtTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictCultAndArtType = await _context.DictCultAndArtType.FindAsync(id);
            if (dictCultAndArtType == null)
            {
                return NotFound();
            }
            ViewData["DictStatusId"] = new SelectList(_context.DictStatus, "Id", "Id", dictCultAndArtType.DictStatusId);
            return View(dictCultAndArtType);
        }

        // POST: GlobalDicts/DictCultAndArtTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NameKyrg,NameRus,DictStatusId,CreateDate")] DictCultAndArtType dictCultAndArtType)
        {
            if (id != dictCultAndArtType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dictCultAndArtType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DictCultAndArtTypeExists(dictCultAndArtType.Id))
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
            ViewData["DictStatusId"] = new SelectList(_context.DictStatus, "Id", "Id", dictCultAndArtType.DictStatusId);
            return View(dictCultAndArtType);
        }

        // GET: GlobalDicts/DictCultAndArtTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictCultAndArtType = await _context.DictCultAndArtType
                .Include(d => d.DictStatus)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dictCultAndArtType == null)
            {
                return NotFound();
            }

            return View(dictCultAndArtType);
        }

        // POST: GlobalDicts/DictCultAndArtTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dictCultAndArtType = await _context.DictCultAndArtType.FindAsync(id);
            _context.DictCultAndArtType.Remove(dictCultAndArtType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DictCultAndArtTypeExists(int id)
        {
            return _context.DictCultAndArtType.Any(e => e.Id == id);
        }
    }
}
