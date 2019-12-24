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
    public class DictEduInstTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DictEduInstTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GlobalDicts/DictEduInstTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.DictEduInstType.ToListAsync());
        }

        // GET: GlobalDicts/DictEduInstTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictEduInstType = await _context.DictEduInstType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dictEduInstType == null)
            {
                return NotFound();
            }

            return View(dictEduInstType);
        }

        // GET: GlobalDicts/DictEduInstTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GlobalDicts/DictEduInstTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NameKyrg,NameRus")] DictEduInstType dictEduInstType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dictEduInstType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dictEduInstType);
        }

        // GET: GlobalDicts/DictEduInstTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictEduInstType = await _context.DictEduInstType.FindAsync(id);
            if (dictEduInstType == null)
            {
                return NotFound();
            }
            return View(dictEduInstType);
        }

        // POST: GlobalDicts/DictEduInstTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NameKyrg,NameRus")] DictEduInstType dictEduInstType)
        {
            if (id != dictEduInstType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dictEduInstType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DictEduInstTypeExists(dictEduInstType.Id))
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
            return View(dictEduInstType);
        }

        // GET: GlobalDicts/DictEduInstTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictEduInstType = await _context.DictEduInstType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dictEduInstType == null)
            {
                return NotFound();
            }

            return View(dictEduInstType);
        }

        // POST: GlobalDicts/DictEduInstTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dictEduInstType = await _context.DictEduInstType.FindAsync(id);
            _context.DictEduInstType.Remove(dictEduInstType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DictEduInstTypeExists(int id)
        {
            return _context.DictEduInstType.Any(e => e.Id == id);
        }
    }
}
