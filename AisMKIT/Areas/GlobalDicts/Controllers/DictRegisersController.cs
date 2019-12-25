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
    public class DictRegisersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DictRegisersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GlobalDicts/DictRegisers
        public async Task<IActionResult> Index()
        {
            return View(await _context.DictRegiser.ToListAsync());
        }

        // GET: GlobalDicts/DictRegisers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictRegiser = await _context.DictRegiser
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dictRegiser == null)
            {
                return NotFound();
            }

            return View(dictRegiser);
        }

        // GET: GlobalDicts/DictRegisers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GlobalDicts/DictRegisers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LastName,FirstName,Patronic")] DictRegiser dictRegiser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dictRegiser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dictRegiser);
        }

        // GET: GlobalDicts/DictRegisers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictRegiser = await _context.DictRegiser.FindAsync(id);
            if (dictRegiser == null)
            {
                return NotFound();
            }
            return View(dictRegiser);
        }

        // POST: GlobalDicts/DictRegisers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LastName,FirstName,Patronic")] DictRegiser dictRegiser)
        {
            if (id != dictRegiser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dictRegiser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DictRegiserExists(dictRegiser.Id))
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
            return View(dictRegiser);
        }

        // GET: GlobalDicts/DictRegisers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictRegiser = await _context.DictRegiser
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dictRegiser == null)
            {
                return NotFound();
            }

            return View(dictRegiser);
        }

        // POST: GlobalDicts/DictRegisers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dictRegiser = await _context.DictRegiser.FindAsync(id);
            _context.DictRegiser.Remove(dictRegiser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DictRegiserExists(int id)
        {
            return _context.DictRegiser.Any(e => e.Id == id);
        }
    }
}
