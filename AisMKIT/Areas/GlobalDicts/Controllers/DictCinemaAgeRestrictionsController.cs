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
    public class DictCinemaAgeRestrictionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DictCinemaAgeRestrictionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GlobalDicts/DictCinemaAgeRestrictions
        public async Task<IActionResult> Index()
        {
            return View(await _context.DictCinemaAgeRestrictions.ToListAsync());
        }

        // GET: GlobalDicts/DictCinemaAgeRestrictions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictCinemaAgeRestrictions = await _context.DictCinemaAgeRestrictions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dictCinemaAgeRestrictions == null)
            {
                return NotFound();
            }

            return View(dictCinemaAgeRestrictions);
        }

        // GET: GlobalDicts/DictCinemaAgeRestrictions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GlobalDicts/DictCinemaAgeRestrictions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] DictCinemaAgeRestrictions dictCinemaAgeRestrictions)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dictCinemaAgeRestrictions);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dictCinemaAgeRestrictions);
        }

        // GET: GlobalDicts/DictCinemaAgeRestrictions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictCinemaAgeRestrictions = await _context.DictCinemaAgeRestrictions.FindAsync(id);
            if (dictCinemaAgeRestrictions == null)
            {
                return NotFound();
            }
            return View(dictCinemaAgeRestrictions);
        }

        // POST: GlobalDicts/DictCinemaAgeRestrictions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] DictCinemaAgeRestrictions dictCinemaAgeRestrictions)
        {
            if (id != dictCinemaAgeRestrictions.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dictCinemaAgeRestrictions);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DictCinemaAgeRestrictionsExists(dictCinemaAgeRestrictions.Id))
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
            return View(dictCinemaAgeRestrictions);
        }

        // GET: GlobalDicts/DictCinemaAgeRestrictions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictCinemaAgeRestrictions = await _context.DictCinemaAgeRestrictions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dictCinemaAgeRestrictions == null)
            {
                return NotFound();
            }

            return View(dictCinemaAgeRestrictions);
        }

        // POST: GlobalDicts/DictCinemaAgeRestrictions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dictCinemaAgeRestrictions = await _context.DictCinemaAgeRestrictions.FindAsync(id);
            _context.DictCinemaAgeRestrictions.Remove(dictCinemaAgeRestrictions);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DictCinemaAgeRestrictionsExists(int id)
        {
            return _context.DictCinemaAgeRestrictions.Any(e => e.Id == id);
        }
    }
}
