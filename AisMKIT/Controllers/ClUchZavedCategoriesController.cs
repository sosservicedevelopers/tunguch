using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AisMKIT.Data;
using AisMKIT.Models;

namespace AisMKIT.Controllers
{
    public class ClUchZavedCategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClUchZavedCategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ClUchZavedCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.ClUchZavedCategory.ToListAsync());
        }

        // GET: ClUchZavedCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clUchZavedCategory = await _context.ClUchZavedCategory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clUchZavedCategory == null)
            {
                return NotFound();
            }

            return View(clUchZavedCategory);
        }

        // GET: ClUchZavedCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClUchZavedCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Desciption")] ClUchZavedCategory clUchZavedCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clUchZavedCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clUchZavedCategory);
        }

        // GET: ClUchZavedCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clUchZavedCategory = await _context.ClUchZavedCategory.FindAsync(id);
            if (clUchZavedCategory == null)
            {
                return NotFound();
            }
            return View(clUchZavedCategory);
        }

        // POST: ClUchZavedCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Desciption")] ClUchZavedCategory clUchZavedCategory)
        {
            if (id != clUchZavedCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clUchZavedCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClUchZavedCategoryExists(clUchZavedCategory.Id))
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
            return View(clUchZavedCategory);
        }

        // GET: ClUchZavedCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clUchZavedCategory = await _context.ClUchZavedCategory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clUchZavedCategory == null)
            {
                return NotFound();
            }

            return View(clUchZavedCategory);
        }

        // POST: ClUchZavedCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clUchZavedCategory = await _context.ClUchZavedCategory.FindAsync(id);
            _context.ClUchZavedCategory.Remove(clUchZavedCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClUchZavedCategoryExists(int id)
        {
            return _context.ClUchZavedCategory.Any(e => e.Id == id);
        }
    }
}
