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
    public class ListOfEducationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ListOfEducationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ListOfEducations
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ListOfEducations.Include(l => l.ClUchZavedCategory);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ListOfEducations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listOfEducations = await _context.ListOfEducations
                .Include(l => l.ClUchZavedCategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (listOfEducations == null)
            {
                return NotFound();
            }

            return View(listOfEducations);
        }

        // GET: ListOfEducations/Create
        public IActionResult Create()
        {
            ViewData["ClUchZavedCategoryId"] = new SelectList(_context.ClUchZavedCategory, "Id", "Name");
            return View();
        }

        // POST: ListOfEducations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,INN,Name,Address,DomenNames,DateOfCreated,ClUchZavedCategoryId")] ListOfEducations listOfEducations)
        {
            if (ModelState.IsValid)
            {
                _context.Add(listOfEducations);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClUchZavedCategoryId"] = new SelectList(_context.ClUchZavedCategory, "Id", "Name", listOfEducations.ClUchZavedCategoryId);
            return View(listOfEducations);
        }

        // GET: ListOfEducations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listOfEducations = await _context.ListOfEducations.FindAsync(id);
            if (listOfEducations == null)
            {
                return NotFound();
            }
            ViewData["ClUchZavedCategoryId"] = new SelectList(_context.ClUchZavedCategory, "Id", "Name", listOfEducations.ClUchZavedCategoryId);
            return View(listOfEducations);
        }

        // POST: ListOfEducations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,INN,Name,Address,DomenNames,DateOfCreated,ClUchZavedCategoryId")] ListOfEducations listOfEducations)
        {
            if (id != listOfEducations.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(listOfEducations);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListOfEducationsExists(listOfEducations.Id))
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
            ViewData["ClUchZavedCategoryId"] = new SelectList(_context.ClUchZavedCategory, "Id", "Name", listOfEducations.ClUchZavedCategoryId);
            return View(listOfEducations);
        }

        // GET: ListOfEducations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listOfEducations = await _context.ListOfEducations
                .Include(l => l.ClUchZavedCategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (listOfEducations == null)
            {
                return NotFound();
            }

            return View(listOfEducations);
        }

        // POST: ListOfEducations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var listOfEducations = await _context.ListOfEducations.FindAsync(id);
            _context.ListOfEducations.Remove(listOfEducations);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ListOfEducationsExists(int id)
        {
            return _context.ListOfEducations.Any(e => e.Id == id);
        }
    }
}
