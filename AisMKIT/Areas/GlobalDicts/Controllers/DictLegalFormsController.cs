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
    public class DictLegalFormsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DictLegalFormsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GlobalDicts/DictLegalForms
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DictLegalForm.Include(d => d.DictStatus);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: GlobalDicts/DictLegalForms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictLegalForm = await _context.DictLegalForm
                .Include(d => d.DictStatus)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dictLegalForm == null)
            {
                return NotFound();
            }

            return View(dictLegalForm);
        }

        // GET: GlobalDicts/DictLegalForms/Create
        public IActionResult Create()
        {
            ViewData["DictStatusId"] = new SelectList(_context.Set<DictStatus>(), "Id", "Name");
            DictLegalForm model = new DictLegalForm();
            model.CreateDate = DateTime.Now;
            model.DeactiveDate = null;
            return View(model);
        }

        // POST: GlobalDicts/DictLegalForms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NameKyrg,NameRus,CreateDate,DictStatusId,DeactiveDate")] DictLegalForm dictLegalForm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dictLegalForm);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DictStatusId"] = new SelectList(_context.Set<DictStatus>(), "Id", "Name", dictLegalForm.DictStatusId);
            return View(dictLegalForm);
        }

        // GET: GlobalDicts/DictLegalForms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictLegalForm = await _context.DictLegalForm.FindAsync(id);
            if (dictLegalForm == null)
            {
                return NotFound();
            }
            ViewData["DictStatusId"] = new SelectList(_context.Set<DictStatus>(), "Id", "Name", dictLegalForm.DictStatusId);
            return View(dictLegalForm);
        }

        // POST: GlobalDicts/DictLegalForms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NameKyrg,NameRus,CreateDate,DictStatusId,DeactiveDate")] DictLegalForm dictLegalForm)
        {
            if (id != dictLegalForm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dictLegalForm);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DictLegalFormExists(dictLegalForm.Id))
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
            ViewData["DictStatusId"] = new SelectList(_context.Set<DictStatus>(), "Id", "Name", dictLegalForm.DictStatusId);
            return View(dictLegalForm);
        }

        // GET: GlobalDicts/DictLegalForms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictLegalForm = await _context.DictLegalForm
                .Include(d => d.DictStatus)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dictLegalForm == null)
            {
                return NotFound();
            }

            return View(dictLegalForm);
        }

        // POST: GlobalDicts/DictLegalForms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dictLegalForm = await _context.DictLegalForm.FindAsync(id);
            _context.DictLegalForm.Remove(dictLegalForm);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DictLegalFormExists(int id)
        {
            return _context.DictLegalForm.Any(e => e.Id == id);
        }
    }
}
