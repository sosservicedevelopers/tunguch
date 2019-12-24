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
    public class DictMonumentTypologicalTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DictMonumentTypologicalTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GlobalDicts/DictMonumentTypologicalTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.DictMonumentTypologicalType.ToListAsync());
        }

        // GET: GlobalDicts/DictMonumentTypologicalTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictMonumentTypologicalType = await _context.DictMonumentTypologicalType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dictMonumentTypologicalType == null)
            {
                return NotFound();
            }

            return View(dictMonumentTypologicalType);
        }

        // GET: GlobalDicts/DictMonumentTypologicalTypes/Create
        public IActionResult Create()
        {
            DictMonumentTypologicalType model = new DictMonumentTypologicalType();
            model.CreateDate = DateTime.Now;
            model.NameKyrg = "Null";
            return View(model);
        }

        // POST: GlobalDicts/DictMonumentTypologicalTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NameKyrg,NameRus,CreateDate")] DictMonumentTypologicalType dictMonumentTypologicalType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dictMonumentTypologicalType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dictMonumentTypologicalType);
        }

        // GET: GlobalDicts/DictMonumentTypologicalTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictMonumentTypologicalType = await _context.DictMonumentTypologicalType.FindAsync(id);
            if (dictMonumentTypologicalType == null)
            {
                return NotFound();
            }
            return View(dictMonumentTypologicalType);
        }

        // POST: GlobalDicts/DictMonumentTypologicalTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NameKyrg,NameRus,CreateDate")] DictMonumentTypologicalType dictMonumentTypologicalType)
        {
            if (id != dictMonumentTypologicalType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dictMonumentTypologicalType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DictMonumentTypologicalTypeExists(dictMonumentTypologicalType.Id))
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
            return View(dictMonumentTypologicalType);
        }

        // GET: GlobalDicts/DictMonumentTypologicalTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictMonumentTypologicalType = await _context.DictMonumentTypologicalType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dictMonumentTypologicalType == null)
            {
                return NotFound();
            }

            return View(dictMonumentTypologicalType);
        }

        // POST: GlobalDicts/DictMonumentTypologicalTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dictMonumentTypologicalType = await _context.DictMonumentTypologicalType.FindAsync(id);
            _context.DictMonumentTypologicalType.Remove(dictMonumentTypologicalType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DictMonumentTypologicalTypeExists(int id)
        {
            return _context.DictMonumentTypologicalType.Any(e => e.Id == id);
        }
    }
}
