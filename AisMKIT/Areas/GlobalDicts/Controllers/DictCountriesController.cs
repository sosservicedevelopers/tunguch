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
    public class DictCountriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DictCountriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GlobalDicts/DictCountries
        public async Task<IActionResult> Index()
        {
            return View(await _context.DictCountry.ToListAsync());
        }

        // GET: GlobalDicts/DictCountries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictCountry = await _context.DictCountry
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dictCountry == null)
            {
                return NotFound();
            }

            return View(dictCountry);
        }

        // GET: GlobalDicts/DictCountries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GlobalDicts/DictCountries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,FullName,English,Alpha2,Alpha3,ISO,Location,LocationPrecise")] DictCountry dictCountry)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dictCountry);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dictCountry);
        }

        // GET: GlobalDicts/DictCountries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictCountry = await _context.DictCountry.FindAsync(id);
            if (dictCountry == null)
            {
                return NotFound();
            }
            return View(dictCountry);
        }

        // POST: GlobalDicts/DictCountries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,FullName,English,Alpha2,Alpha3,ISO,Location,LocationPrecise")] DictCountry dictCountry)
        {
            if (id != dictCountry.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dictCountry);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DictCountryExists(dictCountry.Id))
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
            return View(dictCountry);
        }

        // GET: GlobalDicts/DictCountries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictCountry = await _context.DictCountry
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dictCountry == null)
            {
                return NotFound();
            }

            return View(dictCountry);
        }

        // POST: GlobalDicts/DictCountries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dictCountry = await _context.DictCountry.FindAsync(id);
            _context.DictCountry.Remove(dictCountry);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DictCountryExists(int id)
        {
            return _context.DictCountry.Any(e => e.Id == id);
        }
    }
}
