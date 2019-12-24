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
    public class DictMonumentTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DictMonumentTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GlobalDicts/DictMonumentTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.DictMonumentType.ToListAsync());
        }

        // GET: GlobalDicts/DictMonumentTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictMonumentType = await _context.DictMonumentType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dictMonumentType == null)
            {
                return NotFound();
            }

            return View(dictMonumentType);
        }

        // GET: GlobalDicts/DictMonumentTypes/Create
        public IActionResult Create()
        {
            DictMonumentType model = new DictMonumentType();
            model.CreateDate = DateTime.Now;
            model.NameKyrg = "NULL";
            return View(model);
        }

        // POST: GlobalDicts/DictMonumentTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NameKyrg,NameRus,CreateDate")] DictMonumentType dictMonumentType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dictMonumentType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dictMonumentType);
        }

        // GET: GlobalDicts/DictMonumentTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictMonumentType = await _context.DictMonumentType.FindAsync(id);
            if (dictMonumentType == null)
            {
                return NotFound();
            }
            return View(dictMonumentType);
        }

        // POST: GlobalDicts/DictMonumentTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NameKyrg,NameRus,CreateDate")] DictMonumentType dictMonumentType)
        {
            if (id != dictMonumentType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dictMonumentType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DictMonumentTypeExists(dictMonumentType.Id))
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
            return View(dictMonumentType);
        }

        // GET: GlobalDicts/DictMonumentTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictMonumentType = await _context.DictMonumentType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dictMonumentType == null)
            {
                return NotFound();
            }

            return View(dictMonumentType);
        }

        // POST: GlobalDicts/DictMonumentTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dictMonumentType = await _context.DictMonumentType.FindAsync(id);
            _context.DictMonumentType.Remove(dictMonumentType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DictMonumentTypeExists(int id)
        {
            return _context.DictMonumentType.Any(e => e.Id == id);
        }
    }
}
